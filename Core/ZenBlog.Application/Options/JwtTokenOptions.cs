namespace ZenBlog.Application.Options;

public class JwtTokenOptions
{
    public string Issuer { get; set; }//api.zenblog.com
    public string Audience { get; set; }
    public string Key { get; set; }
    public int ExpireInMinutes { get; set; }

}
