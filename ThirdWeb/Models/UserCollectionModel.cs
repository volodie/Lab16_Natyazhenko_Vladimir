namespace ThirdWeb.Models
{
    [Serializable]
    public class UserCollectionModel
    {
        public List<UserModel> Collection { get; set; }
        public UserCollectionModel()
        {
            Collection = new List<UserModel>();
        }
        public UserCollectionModel(List<UserModel> collection)
        {
            Collection = collection;
        }
    }
}