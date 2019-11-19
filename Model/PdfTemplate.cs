using System;
using System.Collections.Generic;
using System.Text;

namespace ImmigrationFormFiller.Model
{
    

    public class  PdfTemplate
    {
        public class Question
        {
            public string Title { get; set; }
            public string Answer { get; set; }
            public string PdfFeildCode { get; set; }

            public Question(string title , string answer,string pdfFeildCode)
            {
                this.Title = title;
                this.Answer = answer;
                this.PdfFeildCode = pdfFeildCode;

            }
        }
        List<Question> questions = new List<Question>();

        public  PdfTemplate()
        {            
            questions.Add(new Question("isOccupationPublishedOnTFW", "Yes", "EMP5624_E[0].Page1[0].Yes_inn[0]"));
            questions.Add(new Question("isOccupationPublishedOnTFW", "No", "EMP5624_E[0].Page1[0].No_inn[0]"));

            questions.Add(new Question("isEmployerReferedByGTSByPartner", "Yes", "EMP5624_E[0].Page1[0].Yes_business[0]"));
            questions.Add(new Question("isEmployerReferedByGTSByPartner", "No", "EMP5624_E[0].Page1[0].No_business[0]"));

            questions.Add(new Question("PartnerOrganizationName", "", "EMP5624_E[0].Page1[0].txtF_des_part[0]"));
            questions.Add(new Question("PrincipalPartnerContactFirstName", "", "EMP5624_E[0].Page1[0].txtF_first_name[0]"));
            questions.Add(new Question("PrincipalPartnerContactMiddleName", "", "EMP5624_E[0].Page1[0].txtF_mid_name[0]"));
            questions.Add(new Question("PrincipalPartnerContactLastName", "", "EMP5624_E[0].Page1[0].txtF_last_name[0]"));

            questions.Add(new Question("PrincipalPartnerContactTelephone", "", "EMP5624_E[0].Page1[0].txtF_phone_number[0]"));
            questions.Add(new Question("PrincipalPartnerContactTelephone2", "", "EMP5624_E[0].Page1[0].txtF_alternate_phone[0]"));
            questions.Add(new Question("PrincipalPartnerContactFax", "", "EMP5624_E[0].Page1[0].txtF_fax_number[0]"));
            questions.Add(new Question("PrincipalPartnerContactEmail", "", "EMP5624_E[0].Page1[0].txtF_Email[0]"));

            questions.Add(new Question("PrincipalPreferedOralCommunicationLanguage", "English", "EMP5624_E[0].Page1[0].rb_language_oral[0]"));
            questions.Add(new Question("PrincipalPreferedOralCommunicationLanguage", "French", "EMP5624_E[0].Page1[0].rb_language_oral[0].1"));

            questions.Add(new Question("PrincipalPreferedWrittenCommunicationLanguage", "English", "EMP5624_E[0].Page1[0].rb_language_written[0]"));
            questions.Add(new Question("PrincipalPreferedWrittenCommunicationLanguage", "French", "EMP5624_E[0].Page1[0].rb_language_written2[0]"));

            questions.Add(new Question("AlternativePartnerContactFirstName", "", "EMP5624_E[0].Page1[0].txtF_first_name2[0]"));
            questions.Add(new Question("AlternativePartnerContactMiddleName", "", "EMP5624_E[0].Page1[0].txtF_mid_name2[0]"));
            questions.Add(new Question("AlternativePartnerContactLastName", "", "EMP5624_E[0].Page1[0].txtF_last_name2[0]"));

            questions.Add(new Question("AlternativePartnerContactTelephone", "", "EMP5624_E[0].Page1[0].txtF_phone_number2[0]"));

            questions.Add(new Question("AlternativePartnerContactTelephone2", "", "EMP5624_E[0].Page1[0].txtF_alternate_phone2[0]"));
            questions.Add(new Question("AlternativePartnerContactFax", "", "EMP5624_E[0].Page1[0].txtF_fax_number2[0]"));
            questions.Add(new Question("AlternativePartnerContactEmail", "", "EMP5624_E[0].Page1[0].txtF_Email2[0]"));


            questions.Add(new Question("AlternativePreferedOralCommunicationLanguage", "English", "EMP5624_E[0].Page1[0].rb_language_oral2[0].1"));
            questions.Add(new Question("AlternativePreferedOralCommunicationLanguage", "French", "EMP5624_E[0].Page1[0].rb_language_oral2[0].2"));
            questions.Add(new Question("AlternativePreferedWrittenCommunicationLanguage", "English", "EMP5624_E[0].Page1[0].rb_language_written2[0].1"));
            questions.Add(new Question("AlternativePreferedWrittenCommunicationLanguage", "French", "EMP5624_E[0].Page1[0].rb_language_written2[0].2"));







        }

        public string GetPdfFiled(string title,string answer)
        {
            string pdfFieldCode="";
            if (answer.Length > 0)

            {
                Question question = questions.Find(x => x.Answer == answer && x.Title == title);
                if (question != null)
                {
                    pdfFieldCode = question.PdfFeildCode;
                }
                else
                {
                    question = questions.Find(x => x.Title == title);
                    if (question!=null)
                    pdfFieldCode = question.PdfFeildCode;
                }
            }
            return pdfFieldCode;
        }

        public string GetPdfFiled(string title)
        {
            string pdfFieldCode;
            pdfFieldCode = questions.Find(x => x.Title == title).PdfFeildCode;
            return pdfFieldCode;
        }

    }
}
