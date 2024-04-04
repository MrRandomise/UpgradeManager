namespace Game.CoreUpgrade
{
    public interface IUpgrade
    {
        public void AddRequirements(params Upgrade[] requiredUpgrades);
    }
}