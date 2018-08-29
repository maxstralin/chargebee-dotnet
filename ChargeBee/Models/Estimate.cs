using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class Estimate : Resource 
    {
    

        #region Methods
        public static CreateSubscriptionRequest CreateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_subscription");
            return new CreateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static CreateSubForCustomerEstimateRequest CreateSubForCustomerEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "create_subscription_estimate");
            return new CreateSubForCustomerEstimateRequest(url, HttpMethod.GET);
        }
        public static UpdateSubscriptionRequest UpdateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "update_subscription");
            return new UpdateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static RenewalEstimateRequest RenewalEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "renewal_estimate");
            return new RenewalEstimateRequest(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> UpcomingInvoicesEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "upcoming_invoices_estimate");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static ChangeTermEndRequest ChangeTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "change_term_end_estimate");
            return new ChangeTermEndRequest(url, HttpMethod.POST);
        }
        public static CancelSubscriptionRequest CancelSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel_subscription_estimate");
            return new CancelSubscriptionRequest(url, HttpMethod.POST);
        }
        public static PauseSubscriptionRequest PauseSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "pause_subscription_estimate");
            return new PauseSubscriptionRequest(url, HttpMethod.POST);
        }
        public static ResumeSubscriptionRequest ResumeSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "resume_subscription_estimate");
            return new ResumeSubscriptionRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public SubscriptionEstimate SubscriptionEstimate 
        {
            get { return GetSubResource<SubscriptionEstimate>("subscription_estimate"); }
        }
        public InvoiceEstimate InvoiceEstimate 
        {
            get { return GetSubResource<InvoiceEstimate>("invoice_estimate"); }
        }
        public List<InvoiceEstimate> InvoiceEstimates 
        {
            get { return GetResourceList<InvoiceEstimate>("invoice_estimates"); }
        }
        public InvoiceEstimate NextInvoiceEstimate 
        {
            get { return GetSubResource<InvoiceEstimate>("next_invoice_estimate"); }
        }
        public List<CreditNoteEstimate> CreditNoteEstimates 
        {
            get { return GetResourceList<CreditNoteEstimate>("credit_note_estimates"); }
        }
        public List<UnbilledCharge> UnbilledChargeEstimates 
        {
            get { return GetResourceList<UnbilledCharge>("unbilled_charge_estimates"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateSubscriptionRequest : EntityRequest<CreateSubscriptionRequest> 
        {
            public CreateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubscriptionRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public CreateSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateSubscriptionRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public CreateSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public CreateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class CreateSubForCustomerEstimateRequest : EntityRequest<CreateSubForCustomerEstimateRequest> 
        {
            public CreateSubForCustomerEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubForCustomerEstimateRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public CreateSubForCustomerEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubForCustomerEstimateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubForCustomerEstimateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubForCustomerEstimateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubForCustomerEstimateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class UpdateSubscriptionRequest : EntityRequest<UpdateSubscriptionRequest> 
        {
            public UpdateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateSubscriptionRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateSubscriptionRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateSubscriptionRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateSubscriptionRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateSubscriptionRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateSubscriptionRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateSubscriptionRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public UpdateSubscriptionRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public UpdateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public UpdateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public UpdateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public UpdateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class RenewalEstimateRequest : EntityRequest<RenewalEstimateRequest> 
        {
            public RenewalEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RenewalEstimateRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public RenewalEstimateRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public RenewalEstimateRequest IgnoreScheduledCancellation(bool ignoreScheduledCancellation) 
            {
                m_params.AddOpt("ignore_scheduled_cancellation", ignoreScheduledCancellation);
                return this;
            }
            public RenewalEstimateRequest IgnoreScheduledChanges(bool ignoreScheduledChanges) 
            {
                m_params.AddOpt("ignore_scheduled_changes", ignoreScheduledChanges);
                return this;
            }
        }
        public class ChangeTermEndRequest : EntityRequest<ChangeTermEndRequest> 
        {
            public ChangeTermEndRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChangeTermEndRequest TermEndsAt(long termEndsAt) 
            {
                m_params.AddOpt("term_ends_at", termEndsAt);
                return this;
            }
            public ChangeTermEndRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public ChangeTermEndRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
        }
        public class CancelSubscriptionRequest : EntityRequest<CancelSubscriptionRequest> 
        {
            public CancelSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelSubscriptionRequest CreditOptionForCurrentTermCharges(ChargeBee.Models.Enums.CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) 
            {
                m_params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
                return this;
            }
            public CancelSubscriptionRequest UnbilledChargesOption(ChargeBee.Models.Enums.UnbilledChargesOptionEnum unbilledChargesOption) 
            {
                m_params.AddOpt("unbilled_charges_option", unbilledChargesOption);
                return this;
            }
            public CancelSubscriptionRequest AccountReceivablesHandling(ChargeBee.Models.Enums.AccountReceivablesHandlingEnum accountReceivablesHandling) 
            {
                m_params.AddOpt("account_receivables_handling", accountReceivablesHandling);
                return this;
            }
            public CancelSubscriptionRequest RefundableCreditsHandling(ChargeBee.Models.Enums.RefundableCreditsHandlingEnum refundableCreditsHandling) 
            {
                m_params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
                return this;
            }
        }
        public class PauseSubscriptionRequest : EntityRequest<PauseSubscriptionRequest> 
        {
            public PauseSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PauseSubscriptionRequest PauseOption(ChargeBee.Models.Enums.PauseOptionEnum pauseOption) 
            {
                m_params.AddOpt("pause_option", pauseOption);
                return this;
            }
            public PauseSubscriptionRequest UnbilledChargesHandling(ChargeBee.Models.Enums.UnbilledChargesHandlingEnum unbilledChargesHandling) 
            {
                m_params.AddOpt("unbilled_charges_handling", unbilledChargesHandling);
                return this;
            }
            public PauseSubscriptionRequest SubscriptionPauseDate(long subscriptionPauseDate) 
            {
                m_params.AddOpt("subscription[pause_date]", subscriptionPauseDate);
                return this;
            }
            public PauseSubscriptionRequest SubscriptionResumeDate(long subscriptionResumeDate) 
            {
                m_params.AddOpt("subscription[resume_date]", subscriptionResumeDate);
                return this;
            }
        }
        public class ResumeSubscriptionRequest : EntityRequest<ResumeSubscriptionRequest> 
        {
            public ResumeSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ResumeSubscriptionRequest ResumeOption(ChargeBee.Models.Enums.ResumeOptionEnum resumeOption) 
            {
                m_params.AddOpt("resume_option", resumeOption);
                return this;
            }
            public ResumeSubscriptionRequest ChargesHandling(ChargeBee.Models.Enums.ChargesHandlingEnum chargesHandling) 
            {
                m_params.AddOpt("charges_handling", chargesHandling);
                return this;
            }
            public ResumeSubscriptionRequest SubscriptionResumeDate(long subscriptionResumeDate) 
            {
                m_params.AddOpt("subscription[resume_date]", subscriptionResumeDate);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
