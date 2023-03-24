//namespace ProPayApi_MerchantSignup
//{
//    using System;
//    using System.Text;

//    using RestSharp;

//    /*
//    ProPay provides the following code “AS IS.”
//    ProPay makes no warranties and ProPay disclaims all warranties and conditions, express, implied or statutory,
//    including without limitation the implied warranties of title, non-infringement, merchantability, and fitness for a particular purpose.
//    ProPay does not warrant that the code will be uninterrupted or error free,
//    nor does ProPay make any warranty as to the performance or any results that may be obtained by use of the code.
//    */
//    public class MerchantSignupProgram
//    {
//        public static void Main(string[] args)
//        {
//            var merchantSignupResponse = MerchantSignUpForProPay();
//        }

//        /// <summary>
//        /// Signs up a Merchant for ProPay.
//        /// </summary>
//        /// <returns>The response data from the signup call.</returns>
//        private static SignupResponse MerchantSignUpForProPay()
//        {
//            var baseUrl = "https://xmltest.propay.com/propayapi/signup";
//            var request = BuildMerchantTestData();
//            var restRequest = CreateRestRequest("/Signup", Method.Put);
//            restRequest.AddBody(request);
//            return Execute<SignupResponse>(restRequest, baseUrl);
//        }

//        /// <summary>
//        /// Builds the merchant request data.
//        /// </summary>
//        /// <returns>The request data.</returns>
//        private static SignupRequest BuildMerchantTestData()
//        {
//            var userid = "userId";
//            var email = userid + "@test.com";

//            var signupRequest = new SignupRequest
//            {
//                SignupAccountData = new SignupAccountData
//                {
//                    ExternalId = "12345",
//                    Tier = "Premium",
//                    CurrencyCode = "USD",
//                    PhonePIN = "1111",
//                    UserId = userid
//                },
//                Address =
//            new Address
//            {
//                Address1 = "123 Main St.",
//                Address2 = "Suite 5000",
//                ApartmentNumber = "1",
//                City = "Lehi",
//                State = "UT",
//                Country = "USA",
//                Zip = "84013"
//            },
//                BusinessAddress =
//            new Address
//            {
//                Address1 = "Business Address",
//                Address2 = "NW",
//                ApartmentNumber = "333",
//                City = "Lehi",
//                State = "UT",
//                Country = "USA",
//                Zip = "84013"
//            },
//                MailAddress = new Address { Address1 = "101 Box St", City = "Lehi", State = "UT", Country = "USA", Zip = "84013" },
//                BankAccount =
//            new BankAccount
//            {
//                AccountCountryCode = "USA",
//                AccountType = "Checking",
//                AccountOwnershipType = "Business",
//                BankAccountNumber = "123456789",
//                BankName = "CITIZENS BANK NA",
//                RoutingNumber = "011306829"
//            },
//                SecondaryBankAccount =
//            new BankAccount
//            {
//                AccountCountryCode = "USA",
//                AccountType = "Checking",
//                AccountOwnershipType = "Business",
//                BankAccountNumber = "987654321",
//                BankName = "CITIZENS BANK NA",
//                RoutingNumber = "011306829"
//            },
//                BusinessData =
//            new BusinessData
//            {
//                BusinessLegalName = "Propay Merchant",
//                DoingBusinessAs = "Merchant Business",
//                EIN = "121232343",
//            },
//                CreditCardData = new CreditCardData
//                {
//                    CreditCardNumber = "4111111111111111", // test card number
//                    ExpirationDate = DateTime.Now.AddYears(1).ToString("MMyy")
//                },
//                PersonalData =
//            new PersonalData
//            {
//                DateOfBirth = DateTime.Now.AddYears(-30).ToString("MM-dd-yyyy"),
//                SourceEmail = email,
//                SocialSecurityNumber = "333224445",
//                FirstName = "First",
//                LastName = "Last",
//                MiddleInitial = "M",
//                PhoneInformation =
//            new PhoneInformation { DayPhone = "8015551212", EveningPhone = "8015551212" }
//            }
//            };
//            return signupRequest;
//        }

//        /// <summary>
//        /// Request factory to ensure API key is always first parameter added.
//        /// </summary>
//        /// <param name="resource">The resource name.</param>
//        /// <param name="method">The HTTP method.</param>
//        /// <returns>Returns a new <see cref="RestRequest"/>.</returns>
//        private static RestRequest CreateRestRequest(string resource, Method method)
//        {

//            var credentials = GetCredentials();

//            var restRequest = new RestRequest { Resource = resource, Method = method, RequestFormat = DataFormat.Json, };
//            restRequest.AddHeader("accept", "application/json");
//            restRequest.AddHeader("Authorization", credentials);
//            return restRequest;
//        }

//        private static string GetCredentials()
//        {
//            //var termId = "AffTermId01"; // put affiliate term id here, if you have it
//            //var certString = "TestAffiliateMerchCertString01"; // put affiliate cert string here
//            var termId = "83d1858"; // put affiliate term id here, if you have it
//            var certString = "13f79a7a0b8443c88983d1858a4655"; // put affiliate cert string here
//            var encodedCredentials = Convert.ToBase64String(termId == null ? Encoding.Default.GetBytes(certString) : Encoding.Default.GetBytes(certString + ":" + termId));

//            var credentials = string.Format("Basic {0}", encodedCredentials);
//            return credentials;
//        }

//        /// <summary>
//        /// Executes a particular http request to a resource.
//        /// </summary>
//        /// <typeparam name="T">The response type.</typeparam>
//        /// <param name="request">The REST request.</param>
//        /// <param name="baseUrl">The base URL.</param>
//        /// <returns>Returns a response of the type parameter.</returns>
//        private static T Execute<T>(RestRequest request, string baseUrl) where T : class, new()
//        {
//            var client = new RestClient(baseUrl);
//            var response = client.Execute<T>(request);

//            if (response.ErrorException != null)
//            {
//                Console.WriteLine(
//                "Error: Exception: {0}, Headers: {1}, Content: {2}, Status Code: {3}",
//                response.ErrorException,
//                response.Headers,
//                response.Content,
//                response.StatusCode);
//            }

//            return response.Data;
//        }

//        /// <summary>
//        /// Defines request body of a signup request.
//        /// </summary>
//        public class SignupRequest
//        {
//            /// <summary>
//            /// Gets or sets the Personal Data.
//            /// </summary>
//            public PersonalData PersonalData { get; set; }

//            /// <summary>
//            /// Gets or sets the Account Data.
//            /// </summary>
//            public SignupAccountData SignupAccountData { get; set; }

//            /// <summary>
//            /// Gets or sets the Business Data.
//            /// </summary>
//            public BusinessData BusinessData { get; set; }

//            /// <summary>
//            /// Gets or sets the Credit Card Information.
//            /// </summary>
//            public CreditCardData CreditCardData { get; set; }

//            /// <summary>
//            /// Gets or sets the Address.
//            /// </summary>
//            public Address Address { get; set; }

//            /// <summary>
//            /// Gets or sets the MailAddress.
//            /// </summary>
//            public Address MailAddress { get; set; }

//            /// <summary>
//            /// Gets or sets the BusinessAddress.
//            /// </summary>
//            public Address BusinessAddress { get; set; }

//            /// <summary>
//            /// Gets or sets the BankAccount.
//            /// </summary>
//            public BankAccount BankAccount { get; set; }

//            /// <summary>
//            /// Gets or sets the SecondaryBankAccount.
//            /// </summary>
//            public BankAccount SecondaryBankAccount { get; set; }

//            /// <summary>
//            /// Gets or sets the Gross Billing Information.
//            /// </summary>
//            public GrossBillingInformation GrossBillingInformation { get; set; }

//            /// <summary>
//            /// Gets or sets Fraud detection data.
//            /// </summary>
//            public FraudDetectionData FraudDetectionData { get; set; }

//            /// <summary>
//            /// Gets or sets the PaymentMethodId.
//            /// </summary>
//            public string PaymentMethodId { get; set; }
//        }

//        /// <summary>
//        /// Class for personal data like name, DOB.
//        /// </summary>
//        public class PersonalData
//        {
//            /// <summary>
//            /// Gets or sets the SourceEmail.
//            /// </summary>
//            public string SourceEmail { get; set; }

//            /// <summary>
//            /// Gets or sets the FirstName.
//            /// </summary>
//            public string FirstName { get; set; }

//            /// <summary>
//            /// Gets or sets the MiddleInitial.
//            /// </summary>
//            public string MiddleInitial { get; set; }

//            /// <summary>
//            /// Gets or sets the LastName.
//            /// </summary>
//            public string LastName { get; set; }

//            /// <summary>
//            /// Gets or sets the Date of Birth (MM-DD-YYYY).
//            /// </summary>
//            public string DateOfBirth { get; set; }

//            /// <summary>
//            /// Gets or sets the SocialSecurityNumber.
//            /// </summary>
//            public string SocialSecurityNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the Phone Information.
//            /// </summary>
//            public PhoneInformation PhoneInformation { get; set; }

//            /// <summary>
//            /// Gets or sets the International Sign up data.
//            /// </summary>
//            public InternationalSignup InternationalSignUpData { get; set; }
//        }

//        /// <summary>
//        /// Class to collect the Phone Data.
//        /// </summary>
//        public class PhoneInformation
//        {
//            /// <summary>
//            /// Gets or sets the DayPhone.
//            /// </summary>
//            public string DayPhone { get; set; }

//            /// <summary>
//            /// Gets or sets the EveningPhone.
//            /// </summary>
//            public string EveningPhone { get; set; }
//        }

//        /// <summary>
//        /// Class to collect the Data for International Sign ups.
//        /// </summary>
//        public class InternationalSignup
//        {
//            /// <summary>
//            /// Gets or sets International Document Number.
//            /// </summary>
//            public string InternationalId { get; set; }

//            /// <summary>
//            /// Gets or sets Driver License Version.
//            /// </summary>
//            public string DriversLicenseVersion { get; set; }

//            /// <summary>
//            /// Gets or sets Document Type (deeper validation).
//            /// Allowed Values - DriversLicense, Passport or AustralianMedCard.
//            /// </summary>
//            public string DocumentType { get; set; }

//            /// <summary>
//            /// Gets or sets Document Expiration date.
//            /// </summary>
//            public DateTime DocumentExpDate { get; set; }

//            /// <summary>
//            /// Gets or sets Document Issuing state.
//            /// </summary>
//            public string DocumentIssuingState { get; set; }

//            /// <summary>
//            /// Gets or sets Medicate Reference Number.
//            /// </summary>
//            public string MedicareReferenceNumber { get; set; }

//            /// <summary>
//            /// Gets or sets Medicate Card Color.
//            /// </summary>
//            public string MedicareCardColor { get; set; }
//        }

//        /// <summary>
//        /// Attributes for the Account.
//        /// </summary>
//        public class SignupAccountData
//        {
//            /// <summary>
//            /// Gets or sets the CurrencyCode.
//            /// </summary>
//            public string CurrencyCode { get; set; }

//            /// <summary>
//            /// Gets or sets the UserId.
//            /// </summary>
//            public string UserId { get; set; }

//            /// <summary>
//            /// Gets or sets the PhonePIN.
//            /// </summary>
//            public string PhonePIN { get; set; }

//            /// <summary>
//            /// Gets or sets the ExternalId.
//            /// </summary>
//            public string ExternalId { get; set; }

//            /// <summary>
//            /// Gets or sets the Tier.
//            /// </summary>
//            public string Tier { get; set; }
//        }

//        /// <summary>
//        /// Class to represent the Business Data.
//        /// </summary>
//        public class BusinessData
//        {
//            /// <summary>
//            /// Gets or sets the BusinessLegalName.
//            /// </summary>
//            public string BusinessLegalName { get; set; }

//            /// <summary>
//            /// Gets or sets the DoingBusinessAs.
//            /// </summary>
//            public string DoingBusinessAs { get; set; }

//            /// <summary>
//            /// Gets or sets the EIN.
//            /// </summary>
//            public string EIN { get; set; }

//            /// <summary>
//            /// Gets or sets the Merchant Category Code.
//            /// </summary>
//            public string MerchantCategoryCode { get; set; }

//            /// <summary>
//            /// Gets or sets the website url.
//            /// </summary>
//            public string WebsiteURL { get; set; }

//            /// <summary>
//            /// Gets or sets the Business Description.
//            /// </summary>
//            public string BusinessDescription { get; set; }

//            /// <summary>
//            /// Gets or sets the Monthly Card Volume.
//            /// </summary>
//            public long MonthlyBankCardVolume { get; set; }

//            /// <summary>
//            /// Gets or sets the Average Ticket size.
//            /// </summary>
//            public int AverageTicket { get; set; }

//            /// <summary>
//            /// Gets or sets the Highest Ticket Size.
//            /// </summary>
//            public int HighestTicket { get; set; }
//        }

//        /// <summary>
//        /// Class for Credit Card Data.
//        /// </summary>
//        public class CreditCardData
//        {
//            /// <summary>
//            /// Gets or sets the Name on the credit card.
//            /// </summary>
//            public string NameOnCard { get; set; }

//            /// <summary>
//            /// Gets or sets the CreditCardNumber.
//            /// </summary>
//            public string CreditCardNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the ExpirationDate.
//            /// </summary>
//            public string ExpirationDate { get; set; }
//        }

//        /// <summary>
//        /// Address contract.
//        /// </summary>
//        public class Address
//        {
//            /// <summary>
//            /// Gets or sets the ApartmentNumber.
//            /// </summary>
//            public string ApartmentNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the Address1.
//            /// </summary>
//            public string Address1 { get; set; }

//            /// <summary>
//            /// Gets or sets the Address2.
//            /// </summary>
//            public string Address2 { get; set; }

//            /// <summary>
//            /// Gets or sets the City.
//            /// </summary>
//            public string City { get; set; }

//            /// <summary>
//            /// Gets or sets the State.
//            /// </summary>
//            public string State { get; set; }

//            /// <summary>
//            /// Gets or sets the Country.
//            /// </summary>
//            public string Country { get; set; }

//            /// <summary>
//            /// Gets or sets the Zip.
//            /// </summary>
//            public string Zip { get; set; }
//        }

//        /// <summary>
//        /// Bank account contact.
//        /// </summary>
//        public class BankAccount
//        {
//            /// <summary>
//            /// Gets or sets the AccountCountryCode.
//            /// </summary>
//            public string AccountCountryCode { get; set; }

//            /// <summary>
//            /// Gets or sets the BankAccountNumber.
//            /// </summary>
//            public string BankAccountNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the RoutingNumber.
//            /// </summary>
//            public string RoutingNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the AccountOwnershipType.
//            /// </summary>
//            public string AccountOwnershipType { get; set; }

//            /// <summary>
//            /// Gets or sets the BankName.
//            /// </summary>
//            public string BankName { get; set; }

//            /// <summary>
//            /// Gets or sets the AccountType.
//            /// </summary>
//            public string AccountType { get; set; }

//            /// <summary>
//            /// Gets or sets the Account Name.
//            /// </summary>
//            public string AccountName { get; set; }

//            /// <summary>
//            /// Gets or sets the Description.
//            /// </summary>
//            public string Description { get; set; }
//        }

//        /// <summary>
//        /// Class for the Gross Settlement Data.
//        /// </summary>
//        public class GrossBillingInformation
//        {
//            /// <summary>
//            /// Gets or sets the Bank Account information for the Gross Settlement.
//            /// </summary>
//            public BankAccount GrossSettleBankAccount { get; set; }

//            /// <summary>
//            /// Gets or sets the Gross Settle Address.
//            /// </summary>
//            public Address GrossSettleAddress { get; set; }

//            /// <summary>
//            /// Gets or sets the Credit Card Data for Gross Settle.
//            /// </summary>
//            public CreditCardData GrossSettleCardData { get; set; }
//        }

//        /// <summary>
//        /// Class for Collecting Fraud Prevention Data.
//        /// </summary>
//        public class FraudDetectionData
//        {
//            /// <summary>
//            /// Gets or sets the Merchant IP Address.
//            /// </summary>
//            public string MerchantSourceIp { get; set; }

//            /// <summary>
//            /// Gets or sets the Threat Metrix Policy.
//            /// </summary>
//            public string ThreatMetrixPolicy { get; set; }

//            /// <summary>
//            /// Gets or sets the Threat Metrix Session Id.
//            /// </summary>
//            public string ThreatMetrixSessionId { get; set; }
//        }

//        /// <summary>
//        /// Defines response body of a signup request.
//        /// </summary>
//        public class SignupResponse
//        {
//            /// <summary>
//            /// Gets or sets the ProPay account number.
//            /// </summary>
//            public long AccountNumber { get; set; }

//            /// <summary>
//            /// Gets or sets the email address.
//            /// </summary>
//            public string SourceEmail { get; set; }

//            /// <summary>
//            /// Gets or sets the account password.
//            /// </summary>
//            public string Password { get; set; }

//            /// <summary>
//            /// Gets or sets the tier name.
//            /// </summary>
//            public string Tier { get; set; }

//            /// <summary>
//            /// Gets or sets the response status.
//            /// </summary>
//            public string Status { get; set; }
//        }
//    }
//}

namespace ProPayApi_MerchantSignup
{
    using System;
    using System.Runtime.Intrinsics.X86;
    using System.Text;

    using RestSharp;

    /*
    ProPay provides the following code “AS IS.”
    ProPay makes no warranties and ProPay disclaims all warranties and conditions, express, implied or statutory,
    including without limitation the implied warranties of title, non-infringement, merchantability, and fitness for a particular purpose.
    ProPay does not warrant that the code will be uninterrupted or error free,
    nor does ProPay make any warranty as to the performance or any results that may be obtained by use of the code.
    */
    public class MerchantSignupProgram
    {
        public static void Main(string[] args)
        {
            var merchantSignupResponse = MerchantSignUpForProPay();
        }

        /// <summary>
        /// Signs up a Merchant for ProPay.
        /// </summary>
        /// <returns>The response data from the signup call.</returns>
        private static SignupResponse MerchantSignUpForProPay()
        {
            var baseUrl = "https://xmltest.propay.com/propayapi/signup";
            var request = BuildMerchantTestData();
            var restRequest = CreateRestRequest("/Signup", Method.Put);
            restRequest.AddBody(request);
            return Execute<SignupResponse>(restRequest, baseUrl);
        }

        /// <summary>
        /// Builds the merchant request data.
        /// </summary>
        /// <returns>The request data.</returns>
        private static SignupRequest BuildMerchantTestData()
        {
            //var userid = "userId";
            var userid = "83d1858";
            //var email = userid + "@test.com";
            var email = "testrest@propay.com";

            var signupRequest = new SignupRequest
            {
                PersonalData = new PersonalData
                {
                    FirstName = "Customer",
                    MiddleInitial = "X",
                    LastName = "Doe",
                    DateOfBirth = "01-01-1992",
                    SocialSecurityNumber = "123456789",
                    //SourceEmail = "testrest@propay.com",
                    SourceEmail = "testrest@propay.com",
                    PhoneInformation = new PhoneInformation
                    {
                        DayPhone = "DayPhone",
                        EveningPhone = "EveningPhone",
                    },
                    IpSignup= "101.101.101.101",
                    USCitizen= true,
                    BOAttestion=true,
                    TermsAcceptanceIP= "4.14.150.145",
                    TermsAcceptanceTimeStamp= "2022-12-20 12:57:08.2021237",
                    TermsVersion="1",
                    NotificationEmail= "Partner@Partner.com",
                    TimeZone= "UTC"
                },
                SignupAccountData = new SignupAccountData
                {
                    ExternalId = "12345",
                    Tier = "test",
                    CurrencyCode = "USD",
                    PhonePIN = "1111",
                    UserId = userid
                },
                BusinessData =  new BusinessData
                {
                    BusinessLegalName = "Merchantile Parent, Inc.",
                    DoingBusinessAs = "Merchantile ABC",
                    EIN = "121232343",
                    MerchantCategoryCode= "5999",
                    WebsiteURL= "http://Propay.com",
                    BusinessDescription= "Accounting Services",
                    MonthlyBankCardVolume= 10000,
                    AverageTicket= 100,
                    HighestTicket= 250
                },
                Address = new Address
                {
                    ApartmentNumber = "1",
                    Address1 = "3400 N Ashton Blvd",
                    Address2 = "Suite 200",
                    City = "Lehi",
                    State = "UT",
                    Country = "USA",
                    Zip = "84043"
                },
                MailAddress = new Address 
                { 
                    Address1 = "3400 N Ashton Blvd",
                    Address2 = "Suite 200",
                    City = "Lehi",
                    State = "UT",
                    Country = "USA", 
                    Zip = "84043"
                },
                BusinessAddress = new Address
                {
                    ApartmentNumber="200",
                    Address1 = "RR 123445",
                    Address2 = "SW",
                    City = "Tooele",
                    State = "UT",
                    Country = "USA",
                    Zip = "84074"
                },
                BankAccount = new BankAccount
                {
                    AccountCountryCode = "USA",
                    BankAccountNumber = "123456789",
                    RoutingNumber = "011306829",
                    AccountOwnershipType = "Business",
                    AccountType = "Checking",
                    BankName = "MERCHANTILE BANK UT",
                    AccountName= null,
                    Description=null
                },
                Devices = new Devices
                {
                    Name = "Secure Submit",
                    Quantity = 1
                },
                BeneficialOwnerData = new BeneficialOwnerData
                {
                    OwnerCount= "1",
                    Owners = new Owners
                    {
                        FirstName= "First1",
                        LastName = "Last1",
                        SSN= "123456789",
                        DateOfBirth= "01-01-1981",
                        Email= "test1@qamail.com",
                        Address="Address",
                        City= "Lehi",
                        State= "UT",
                        Zip= "84010",
                        Country= "USA",
                        Title= "CEO",
                        Percentage ="100"
                    }
                },
                CreditCardData = new CreditCardData
                {
                    CreditCardNumber = "4111111111111111", // test card number
                    ExpirationDate = DateTime.Now.AddYears(1).ToString("MMyy")
                },
            };
            return signupRequest;
        }

        /// <summary>
        /// Request factory to ensure API key is always first parameter added.
        /// </summary>
        /// <param name="resource">The resource name.</param>
        /// <param name="method">The HTTP method.</param>
        /// <returns>Returns a new <see cref="RestRequest"/>.</returns>
        private static RestRequest CreateRestRequest(string resource, Method method)
        {

            var credentials = GetCredentials();

            var restRequest = new RestRequest { Resource = resource, Method = method, RequestFormat = DataFormat.Json, };
            restRequest.AddHeader("accept", "application/json");
            restRequest.AddHeader("Authorization", credentials);
            return restRequest;
        }

        private static string GetCredentials()
        {
            var termId = "83d1858"; // put affiliate term id here, if you have it
            var certString = "13f79a7a0b8443c88983d1858a4655"; // put affiliate cert string here
            var encodedCredentials = Convert.ToBase64String(termId == null ? Encoding.Default.GetBytes(certString) : Encoding.Default.GetBytes(certString + ":" + termId));

            var credentials = string.Format("Basic {0}", encodedCredentials);
            return credentials;
        }

        /// <summary>
        /// Executes a particular http request to a resource.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="request">The REST request.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns>Returns a response of the type parameter.</returns>
        private static T Execute<T>(RestRequest request, string baseUrl) where T : class, new()
        {
            var client = new RestClient(baseUrl);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                Console.WriteLine(
                "Error: Exception: {0}, Headers: {1}, Content: {2}, Status Code: {3}",
                response.ErrorException,
                response.Headers,
                response.Content,
                response.StatusCode);
            }

            return response.Data;
        }

        /// <summary>
        /// Defines request body of a signup request.
        /// </summary>
        public class SignupRequest
        {
            /// <summary>
            /// Gets or sets the Personal Data.
            /// </summary>
            public PersonalData PersonalData { get; set; }

            /// <summary>
            /// Gets or sets the Account Data.
            /// </summary>
            public SignupAccountData SignupAccountData { get; set; }

            /// <summary>
            /// Gets or sets the Business Data.
            /// </summary>
            public BusinessData BusinessData { get; set; }

            /// <summary>
            /// Gets or sets the Credit Card Information.
            /// </summary>
            public CreditCardData CreditCardData { get; set; }

            /// <summary>
            /// Gets or sets the Address.
            /// </summary>
            public Address Address { get; set; }

            /// <summary>
            /// Gets or sets the MailAddress.
            /// </summary>
            public Address MailAddress { get; set; }

            /// <summary>
            /// Gets or sets the BusinessAddress.
            /// </summary>
            public Address BusinessAddress { get; set; }

            /// <summary>
            /// Gets or sets the BankAccount.
            /// </summary>
            public BankAccount BankAccount { get; set; }

            #region added by krina
            public Devices Devices { get; set; }

            public BeneficialOwnerData BeneficialOwnerData { get; set; }

            #endregion
            /// <summary>
            /// Gets or sets the SecondaryBankAccount.
            /// </summary>
            public BankAccount SecondaryBankAccount { get; set; }

            /// <summary>
            /// Gets or sets the Gross Billing Information.
            /// </summary>
            public GrossBillingInformation GrossBillingInformation { get; set; }

            /// <summary>
            /// Gets or sets Fraud detection data.
            /// </summary>
            public FraudDetectionData FraudDetectionData { get; set; }

            /// <summary>
            /// Gets or sets the PaymentMethodId.
            /// </summary>
            public string PaymentMethodId { get; set; }
        }

        /// <summary>
        /// Class for personal data like name, DOB.
        /// </summary>
        public class PersonalData
        {
            /// <summary>
            /// Gets or sets the SourceEmail.
            /// </summary>
            public string SourceEmail { get; set; }

            /// <summary>
            /// Gets or sets the FirstName.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the MiddleInitial.
            /// </summary>
            public string MiddleInitial { get; set; }

            /// <summary>
            /// Gets or sets the LastName.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Gets or sets the Date of Birth (MM-DD-YYYY).
            /// </summary>
            public string DateOfBirth { get; set; }

            /// <summary>
            /// Gets or sets the SocialSecurityNumber.
            /// </summary>
            public string SocialSecurityNumber { get; set; }

            /// <summary>
            /// Gets or sets the Phone Information.
            /// </summary>
            public PhoneInformation PhoneInformation { get; set; }

            /// <summary>
            /// Gets or sets the International Sign up data.
            /// </summary>
            public InternationalSignup InternationalSignUpData { get; set; }
            public string IpSignup { get; set; }
            public bool USCitizen { get; set; }
            public bool BOAttestion { get; set; }
            public string TermsAcceptanceIP { get; set; }
            public string TermsAcceptanceTimeStamp { get; set; }
            public string TermsVersion { get; set; }
            public string NotificationEmail { get; set; }
            public string TimeZone { get; set; }
        }

        /// <summary>
        /// Class to collect the Phone Data.
        /// </summary>
        public class PhoneInformation
        {
            /// <summary>
            /// Gets or sets the DayPhone.
            /// </summary>
            public string DayPhone { get; set; }

            /// <summary>
            /// Gets or sets the EveningPhone.
            /// </summary>
            public string EveningPhone { get; set; }
        }

        /// <summary>
        /// Class to collect the Data for International Sign ups.
        /// </summary>
        public class InternationalSignup
        {
            /// <summary>
            /// Gets or sets International Document Number.
            /// </summary>
            public string InternationalId { get; set; }

            /// <summary>
            /// Gets or sets Driver License Version.
            /// </summary>
            public string DriversLicenseVersion { get; set; }

            /// <summary>
            /// Gets or sets Document Type (deeper validation).
            /// Allowed Values - DriversLicense, Passport or AustralianMedCard.
            /// </summary>
            public string DocumentType { get; set; }

            /// <summary>
            /// Gets or sets Document Expiration date.
            /// </summary>
            public DateTime DocumentExpDate { get; set; }

            /// <summary>
            /// Gets or sets Document Issuing state.
            /// </summary>
            public string DocumentIssuingState { get; set; }

            /// <summary>
            /// Gets or sets Medicate Reference Number.
            /// </summary>
            public string MedicareReferenceNumber { get; set; }

            /// <summary>
            /// Gets or sets Medicate Card Color.
            /// </summary>
            public string MedicareCardColor { get; set; }
        }

        /// <summary>
        /// Attributes for the Account.
        /// </summary>
        public class SignupAccountData
        {
            /// <summary>
            /// Gets or sets the CurrencyCode.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// Gets or sets the UserId.
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// Gets or sets the PhonePIN.
            /// </summary>
            public string PhonePIN { get; set; }

            /// <summary>
            /// Gets or sets the ExternalId.
            /// </summary>
            public string ExternalId { get; set; }

            /// <summary>
            /// Gets or sets the Tier.
            /// </summary>
            public string Tier { get; set; }
        }

        /// <summary>
        /// Class to represent the Business Data.
        /// </summary>
        public class BusinessData
        {
            /// <summary>
            /// Gets or sets the BusinessLegalName.
            /// </summary>
            public string BusinessLegalName { get; set; }

            /// <summary>
            /// Gets or sets the DoingBusinessAs.
            /// </summary>
            public string DoingBusinessAs { get; set; }

            /// <summary>
            /// Gets or sets the EIN.
            /// </summary>
            public string EIN { get; set; }

            /// <summary>
            /// Gets or sets the Merchant Category Code.
            /// </summary>
            public string MerchantCategoryCode { get; set; }

            /// <summary>
            /// Gets or sets the website url.
            /// </summary>
            public string WebsiteURL { get; set; }

            /// <summary>
            /// Gets or sets the Business Description.
            /// </summary>
            public string BusinessDescription { get; set; }

            /// <summary>
            /// Gets or sets the Monthly Card Volume.
            /// </summary>
            public long MonthlyBankCardVolume { get; set; }

            /// <summary>
            /// Gets or sets the Average Ticket size.
            /// </summary>
            public int AverageTicket { get; set; }

            /// <summary>
            /// Gets or sets the Highest Ticket Size.
            /// </summary>
            public int HighestTicket { get; set; }
        }

        /// <summary>
        /// Class for Credit Card Data.
        /// </summary>
        public class CreditCardData
        {
            /// <summary>
            /// Gets or sets the Name on the credit card.
            /// </summary>
            public string NameOnCard { get; set; }

            /// <summary>
            /// Gets or sets the CreditCardNumber.
            /// </summary>
            public string CreditCardNumber { get; set; }

            /// <summary>
            /// Gets or sets the ExpirationDate.
            /// </summary>
            public string ExpirationDate { get; set; }
        }

        /// <summary>
        /// Address contract.
        /// </summary>
        public class Address
        {
            /// <summary>
            /// Gets or sets the ApartmentNumber.
            /// </summary>
            public string ApartmentNumber { get; set; }

            /// <summary>
            /// Gets or sets the Address1.
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// Gets or sets the Address2.
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// Gets or sets the City.
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// Gets or sets the State.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Gets or sets the Country.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// Gets or sets the Zip.
            /// </summary>
            public string Zip { get; set; }
        }

        /// <summary>
        /// Bank account contact.
        /// </summary>
        public class BankAccount
        {
            /// <summary>
            /// Gets or sets the AccountCountryCode.
            /// </summary>
            public string AccountCountryCode { get; set; }

            /// <summary>
            /// Gets or sets the BankAccountNumber.
            /// </summary>
            public string BankAccountNumber { get; set; }

            /// <summary>
            /// Gets or sets the RoutingNumber.
            /// </summary>
            public string RoutingNumber { get; set; }

            /// <summary>
            /// Gets or sets the AccountOwnershipType.
            /// </summary>
            public string AccountOwnershipType { get; set; }

            /// <summary>
            /// Gets or sets the BankName.
            /// </summary>
            public string BankName { get; set; }

            /// <summary>
            /// Gets or sets the AccountType.
            /// </summary>
            public string AccountType { get; set; }

            /// <summary>
            /// Gets or sets the Account Name.
            /// </summary>
            public string AccountName { get; set; }

            /// <summary>
            /// Gets or sets the Description.
            /// </summary>
            public string Description { get; set; }
        }

        /// <summary>
        /// Class for the Gross Settlement Data.
        /// </summary>
        public class GrossBillingInformation
        {
            /// <summary>
            /// Gets or sets the Bank Account information for the Gross Settlement.
            /// </summary>
            public BankAccount GrossSettleBankAccount { get; set; }

            /// <summary>
            /// Gets or sets the Gross Settle Address.
            /// </summary>
            public Address GrossSettleAddress { get; set; }

            /// <summary>
            /// Gets or sets the Credit Card Data for Gross Settle.
            /// </summary>
            public CreditCardData GrossSettleCardData { get; set; }
        }

        /// <summary>
        /// Class for Collecting Fraud Prevention Data.
        /// </summary>
        public class FraudDetectionData
        {
            /// <summary>
            /// Gets or sets the Merchant IP Address.
            /// </summary>
            public string MerchantSourceIp { get; set; }

            /// <summary>
            /// Gets or sets the Threat Metrix Policy.
            /// </summary>
            public string ThreatMetrixPolicy { get; set; }

            /// <summary>
            /// Gets or sets the Threat Metrix Session Id.
            /// </summary>
            public string ThreatMetrixSessionId { get; set; }
        }

        /// <summary>
        /// Defines response body of a signup request.
        /// </summary>
        public class SignupResponse
        {
            /// <summary>
            /// Gets or sets the ProPay account number.
            /// </summary>
            public long AccountNumber { get; set; }

            /// <summary>
            /// Gets or sets the email address.
            /// </summary>
            public string SourceEmail { get; set; }

            /// <summary>
            /// Gets or sets the account password.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets the tier name.
            /// </summary>
            public string Tier { get; set; }

            /// <summary>
            /// Gets or sets the response status.
            /// </summary>
            public string Status { get; set; }
        }

        #region added by krina
        public class Devices
        {
            public string Name { get; set;}
            public int Quantity { get; set; }
        }
        public class BeneficialOwnerData 
        {
            public string OwnerCount { get; set; }
            public Owners Owners { get; set; }
        }
        public class Owners
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SSN { get; set; }
            public string DateOfBirth { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Country { get; set; }
            public string Title { get; set; }
            public string Percentage { get; set; }
        }
        #endregion
    }
}