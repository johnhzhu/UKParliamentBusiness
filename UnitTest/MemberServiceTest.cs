using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HOCBusiness.Services;
using HOCBusiness.Domain;

namespace HOCBusiness.UnitTest
{
    [TestClass]
    public class MemberServiceTest
    {
        [TestMethod]
        public void MemberIDMatch()
        {
            int id = 579;
            var data = GetMemberData(id);
            Assert.AreEqual(data.Member_Id, id.ToString());
        }

        [TestMethod]
        public void OutputResponse()
        {
            int id = 579;
            var data = GetMemberData(id);
            Console.WriteLine($"FullTitle: {data.FullTitle}");
            Console.WriteLine($"MemberFrom: {data.MemberFrom}");
            Console.WriteLine($"MemberId: {data.Member_Id}");
            Console.WriteLine($"Clerks_Id: {data.Clerks_Id}");
            Console.WriteLine($"CurrentStatus: {data.CurrentStatus}");
            Console.WriteLine($"DateOfBirth: {data.DateOfBirth?.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"DateOfDeath: {data.DateOfDeath?.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"DisplayAs: {data.DisplayAs}");
            Console.WriteLine($"Dods_Id: {data.Dods_Id}");
            Console.WriteLine($"Gender: {data.Gender}");
            Console.WriteLine($"House: {data.House}");
            Console.WriteLine($"HouseEndDate: {data.HouseEndDate?.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"HouseStartDate: {data.HouseStartDate?.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"LayingMinisterName: {data.LayingMinisterName}");
            Console.WriteLine($"PartyName: {data.Party.Name}");
            Console.WriteLine($"PartyId: {data.Party.Id}");
            Console.WriteLine($"Pims_Id: {data.Pims_Id}");
        }

        private Member GetMemberData(int id)
        {
            return new MemberService().GetMember(id);
        }
    }
}
