namespace MyChat_API.DTOs
{
    public class RTCIceCandidateDTO
    {
        public string Candidate { get; set; }
        public int SdpMLineIndex { get; set; }
        public string SdpMid { get; set; }
    }
}
