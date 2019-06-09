using HOCBusiness.Domain;

namespace HOCBusiness.Services
{
    public class MemberService : BaseService
    {
        private readonly string _baseUrl = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id=";

        public MemberService()
        {
            this.BaseUrl = _baseUrl;
        }

        public Member GetMember(int id)
        {
            return base.DeserialiseXml<MemberList>($"{this.BaseUrl}{id}").Member;
        }
    }
}
