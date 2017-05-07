namespace HandmadeItemMarket.Data.Mocks.DbSets
{
    using System.Linq;
    using Models.EntityModels;
    public class MockedCategoriesDbSet: MockedDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            int wantedId = (int) keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
        
    }
}