using System;
using System.Collections.Generic;
using System.Text;

namespace ImmigrationFormFiller
{
    public class Candidate
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public string[] Skills { get {
                return this.SkillsAsText.Replace(", ", ",").Split(',');
            } }
        public string SkillsAsText { get; set; }
        public string Position { get; set; }

        public Candidate(int userid, int jobid, string skills, string position)
        {
            this.UserId = userid;
            this.JobId = jobid;
            this.Position = position;
            this.SkillsAsText = skills;
        }

        //public Candidate(int userid, int jobid, string[] skills, string position)
        //{
        //    CreateCandidate(userid, jobid, skills, position);
        //}
        //public Candidate(int userid, int jobid, string skills, string position)
        //{
        //    string[] SkillAsArray = skills.Replace(", ", ",").Split(',');
        //    CreateCandidate(userid, jobid, SkillAsArray, position);
        //}
        
    }


}
