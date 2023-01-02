using System.Net;


namespace PracticeCoreWebApi.Model
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string SpecialPower { get; set; } = string.Empty;
        public string HisMovieName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
    }

    public class SuperHeroResponseModel
    {
        public SuperHeroResponseModel()
        {
            CommonResponseStatus = new CommonResponseStatus();
        }
        public CommonResponseStatus CommonResponseStatus { get; set; }
        public SuperHero SuperHero { get; set; }
        public List<SuperHero> lstSuperHero { get; set; }
    }

    public class CommonResponseStatus
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }

    public class APIResultItem<T> where T : class
    {
        public T ? Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ? ErrorGUID { get; set; }
    }

    public class APIResultItems<T> where T : class
    {
        public List<T> ? Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ? ErrorGUID { get; set; }
    }

}
