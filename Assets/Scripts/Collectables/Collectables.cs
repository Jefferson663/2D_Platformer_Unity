

public class Collectables
{
    protected string name;
    protected string description;
    protected int total;
    protected PlayerCollectables inventory = PlayerCollectables.GetInstace();

    public Collectables(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
    public string Name()
    {
        return this.name;
    }
    public int Total()
    {
        return this.total;
    }
    public string Description()
    {
        return this.description;
    }
    public void Add()
    {
        this.total++;
    }
    public void Add(int quantity)
    {
        this.total += quantity;
    }
    public void PutInInventory()
    {
        inventory.AddCollectable(this);
    }
}