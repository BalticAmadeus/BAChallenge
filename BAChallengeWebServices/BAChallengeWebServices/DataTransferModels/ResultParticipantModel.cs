namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, to create resultParticipant object and add created object to ParticipantModel
    /// </summary>
    public class ResultParticipantModel
    {
        public int ResultId { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }

    }
}