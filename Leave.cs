using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    interface IApprovalSummary
    {
        string GetSummary();
    }

    abstract class LeavePolicy
    {
        public string Name;
        public int Days;

        public LeavePolicy(string name, int days)
        {
            Name = name;
            Days = days;
        }

        public abstract bool Validate();
    }

    class AnnualLeavePolicy : LeavePolicy, IApprovalSummary
    {
        public AnnualLeavePolicy(string name, int days) : base(name, days) { }

        public override bool Validate()
        {
            return Days > 0 && Days <= 20;
        }

        public string GetSummary()
        {
            return Name + " Annual Leave " + Validate();
        }
    }

    class SickLeavePolicy : LeavePolicy, IApprovalSummary
    {
        public SickLeavePolicy(string name, int days) : base(name, days) { }

        public override bool Validate()
        {
            return Days > 0 && Days <= 10;
        }

        public string GetSummary()
        {
            return Name + " Sick Leave" + Validate();
        }
    }

    public class Leave
    {
        public static void Main(string[] args)
        {

        
        LeavePolicy[] r =
       {
            new AnnualLeavePolicy("Meghana",0),
            new AnnualLeavePolicy("Meghana",5),
            new SickLeavePolicy("Meghana",25)
        };

        foreach (LeavePolicy leave in r )
        {
            Console.WriteLine("Valid: " + leave.Validate());

            IApprovalSummary summary = (IApprovalSummary)leave;
        Console.WriteLine(summary.GetSummary());
        }
    }
}
}

