namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, to create resultParticipant results 
    /// </summary>
    public class ResultParticipantModel
    {
        public int ResultId { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }

    }
}