using System;
using System.Collections.Generic;
using System.Text;

namespace ImmigrationFormFiller.Model
{
   public class Talent
    {
        public string id { get; set; }
        public string isOccupationPublishedOnTFW { get; set; }
        public string isEmployerReferedByGTSByPartner { get; set; }
        public string PartnerOrganizationName { get; set; }
        public string PrincipalPartnerContactFirstName { get; set; }
        public string PrincipalPartnerContactMiddleName { get; set; }
        public string PrincipalPartnerContactLastName { get; set; }
        public string PrincipalPartnerContactTelephone { get; set; }
        public string PrincipalPartnerContactTelephone2 { get; set; }
        public string PrincipalPartnerContactFax { get; set; }
        public string PrincipalPartnerContactEmail { get; set; }
        public string PrincipalPreferedOralCommunicationLanguage { get; set; }
        public string PrincipalPreferedWrittenCommunicationLanguage { get; set; }
        public string AlternativePartnerOrganizationName { get; set; }
        public string AlternativePartnerContactFirstName { get; set; }
        public string AlternativePartnerContactLastName { get; set; }
        public string AlternativePartnerContactMiddleName { get; set; }
        public string AlternativePreferedOralCommunicationLanguage { get; set; }
        public string AlternativePreferedWrittenCommunicationLanguage { get; set; }
        public string AlternativePartnerContactTelephone { get; set; }
        public string AlternativePartnerContactTelephone2 { get; set; }
        public string AlternativePartnerContactFax { get; set; }
        public string AlternativePartnerContactEmail { get; set; }


        public Talent
            (
            string _id,
            string _isOccupationPublishedOnTFW, 
            string _isEmployerReferedByGTSByPartner, 
            string _PartnerOrganizationName, 
            string _PrincipalPartnerContactFirstName, 
            string _PrincipalPartnerContactMiddleName, 
            string _PrincipalPartnerContactLastName, 
            string _PrincipalPartnerContactTelephone, 
            string _PrincipalPartnerContactTelephone2, 
            string _PrincipalPartnerContactFax, 
            string _PrincipalPartnerContactEmail, 
            string _PrincipalPreferedOralCommunicationLanguage, 
            string _PrincipalPreferedWrittenCommunicationLanguage, 
            string _AlternativePartnerOrganizationName, 
            string _AlternativePartnerContactFirstName,
            string _AlternativePartnerContactLastName, 
            string _AlternativePartnerContactMiddleName,
            string _AlternativePreferedOralCommunicationLanguage, 
            string _AlternativePreferedWrittenCommunicationLanguage, 
            string _AlternativePartnerContactTelephone,
            string _AlternativePartnerContactTelephone2, 
            string _AlternativePartnerContactFax,
            string _AlternativePartnerContactEmail
            )
        {

            this.id= _id;
            this.isOccupationPublishedOnTFW = _isOccupationPublishedOnTFW;
            this.isEmployerReferedByGTSByPartner = _isEmployerReferedByGTSByPartner;
            this.PartnerOrganizationName = _PartnerOrganizationName;
            this.PrincipalPartnerContactFirstName = _PrincipalPartnerContactFirstName;
            this.PrincipalPartnerContactMiddleName = _PrincipalPartnerContactMiddleName;
            this.PrincipalPartnerContactLastName = _PrincipalPartnerContactLastName;
            this.PrincipalPartnerContactTelephone = _PrincipalPartnerContactTelephone;
            this.PrincipalPartnerContactTelephone2 = _PrincipalPartnerContactTelephone2;
            this.PrincipalPartnerContactFax = _PrincipalPartnerContactFax;
            this.PrincipalPartnerContactEmail = _PrincipalPartnerContactEmail;
            this.PrincipalPreferedOralCommunicationLanguage = _PrincipalPreferedOralCommunicationLanguage;
            this.PrincipalPreferedWrittenCommunicationLanguage = _PrincipalPreferedWrittenCommunicationLanguage;
            this.AlternativePartnerOrganizationName = _AlternativePartnerOrganizationName;
            this.AlternativePartnerContactFirstName = _AlternativePartnerContactFirstName;
            this.AlternativePartnerContactLastName = _AlternativePartnerContactLastName;
            this.AlternativePartnerContactMiddleName = _AlternativePartnerContactMiddleName;
            this.AlternativePreferedOralCommunicationLanguage = _AlternativePreferedOralCommunicationLanguage;
            this.AlternativePreferedWrittenCommunicationLanguage = _AlternativePreferedWrittenCommunicationLanguage;
            this.AlternativePartnerContactTelephone = _AlternativePartnerContactTelephone;
            this.AlternativePartnerContactTelephone2 = _AlternativePartnerContactTelephone2;
            this.AlternativePartnerContactFax = _AlternativePartnerContactFax;
            this.AlternativePartnerContactEmail = _AlternativePartnerContactEmail;


        }
    }
    
}
