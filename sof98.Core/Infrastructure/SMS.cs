using Kavenegar;

namespace soft98.Core.Infrastructure
{
    
    public class SMS
    {
        public void Send(string To, string body)
        {
            var sender = "100047778";
            var receptor = To;
            var message = body;
            var api = new Kavenegar.KavenegarApi("4E4A59367458317748766A2B44733544786E334B31743956586A5878625674446337545330305370534A303D");
            api.Send(sender, receptor, message);
        }
    }
}