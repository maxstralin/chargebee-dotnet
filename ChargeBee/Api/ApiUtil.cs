using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;

using ChargeBee.Exceptions;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ChargeBee.Api
{
    public static class ApiUtil
    {
        private static DateTime m_unixTime = new DateTime(1970, 1, 1);

        public static string BuildUrl(params string[] paths)
        {
            StringBuilder sb = new StringBuilder(ApiConfig.Instance.ApiBaseUrl);

            foreach (var path in paths)
            {
				sb.Append('/').Append(WebUtility.UrlEncode(path));
            }

            return sb.ToString();
        }

		private static HttpWebRequest GetRequest(string url, HttpMethod method, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
			request.Method = Enum.GetName(typeof(HttpMethod), method);

	     request.Accept = "application/json";

			AddHeaders (request, env);
			AddCustomHeaders (request, headers);


            return request;
        }

		private static void AddHeaders(HttpWebRequest request, ApiConfig env) {
			request.Headers[HttpRequestHeader.AcceptCharset] = env.Charset;
			request.Headers[HttpRequestHeader.Authorization] = env.AuthValue;
		}

		private static void AddCustomHeaders(HttpWebRequest request, Dictionary<string, string> headers) {
			foreach (KeyValuePair<string, string> entry in headers) {
					AddHeader(request, entry.Key, entry.Value);
			}
		}

		private static void AddHeader(HttpWebRequest request, String headerName, String value) {
			request.Headers[headerName] =  value;
		}

        private static string SendRequest(HttpWebRequest request, out HttpStatusCode code)
        {
            try
            {
                using (HttpWebResponse response = request.GetResponseAsync().Result as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    code = response.StatusCode;
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null) throw ex;
                using (HttpWebResponse response = ex.Response as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    code = response.StatusCode;
                    string content = reader.ReadToEnd();
					Dictionary<string, string> errorJson = null;
					try {
						errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>> (content);
					} catch(JsonException e) {
						throw new Exception("Not in JSON format. Probably not a ChargeBee response. \n " + content, e);
					}
					string type = "";
					errorJson.TryGetValue ("type", out type);
					if ("payment".Equals (type)) {
						throw new PaymentException (response.StatusCode, errorJson);
					} else if ("operation_failed".Equals (type)) {
						throw new OperationFailedException (response.StatusCode, errorJson);
					} else if ("invalid_request".Equals(type)){
						throw new InvalidRequestException (response.StatusCode, errorJson);
					} else {
						throw new ApiException(response.StatusCode, errorJson);
					}
                }
            }
        }

		private static string GetJson(string url, Params parameters, ApiConfig env, Dictionary<string, string> headers, out HttpStatusCode code,bool IsList)
        {
			url = String.Format("{0}?{1}", url, parameters.GetQuery(IsList));
			HttpWebRequest request = GetRequest(url, HttpMethod.GET, headers, env);
            return SendRequest(request, out code);
        }

        public static EntityResult Post(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            return PostAsync(url, parameters, headers, env).Result;
        }

        public static async Task<EntityResult> PostAsync(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
			HttpWebRequest request = GetRequest(url, HttpMethod.POST, headers, env);
            byte[] paramsBytes =
				Encoding.GetEncoding(env.Charset).GetBytes(parameters.GetQuery(false));

            request.ContentType = 
				String.Format("application/x-www-form-urlencoded;charset={0}",env.Charset);
            using (Stream stream = await request.GetRequestStreamAsync())
            {
                stream.Write(paramsBytes, 0, paramsBytes.Length);

                HttpStatusCode code;
                string json = SendRequest(request, out code);

                EntityResult result = new EntityResult(code, json);
                return result;
            }
        }

		public static EntityResult Get(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpStatusCode code;
			string json = GetJson(url, parameters, env, headers, out code,false);

            EntityResult result = new EntityResult(code, json);
            return result;
        }

		public static ListResult GetList(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpStatusCode code;
            string json = GetJson(url, parameters, env, headers, out code,true);

            ListResult result = new ListResult(code, json);
            return result;
        }

        public static DateTime ConvertFromTimestamp(long timestamp)
        {
            return m_unixTime.AddSeconds(timestamp).ToLocalTime();
        }

        public static long? ConvertToTimestamp(DateTime? t)
        {
            if (t == null) return null;

            DateTime dtutc = ((DateTime)t).ToUniversalTime();

            if (dtutc < m_unixTime) throw new ArgumentException("Time can't be before 1970, January 1!");

            return (long)(dtutc - m_unixTime).TotalSeconds;
        }
    }

    /// <summary>
    /// HTTP method
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// DELETE
        /// </summary>
        DELETE,
        /// <summary>
        /// GET
        /// </summary>
        GET,
        /// <summary>
        /// POST
        /// </summary>
        POST,
        /// <summary>
        /// PUT
        /// </summary>
        PUT
    }
}
