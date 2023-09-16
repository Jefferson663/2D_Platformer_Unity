using System.Collections.Generic;

public class PlayerCollectables
{
    private static PlayerCollectables instance;
    private List<Collectables> collectedCollectables;

    
    public static PlayerCollectables GetInstace()
    {
        if (instance == null)
            instance = new PlayerCollectables();
        return instance;
    }
    private PlayerCollectables()
    {
        collectedCollectables = new List<Collectables>();
    }
    public void AddCollectable(Collectables itemToAdd)
    {
        foreach (Collectables item in collectedCollectables)
        {
            if(item.Name() == itemToAdd.Name())
            {
                item.Add();
                return;
            }
        }
        collectedCollectables.Add(itemToAdd);
    }
    public void AddCollectable(Collectables itemToAdd, int quantity)
    {
        foreach (Collectables item in collectedCollectables)
        {
            if (item.Name() == itemToAdd.Name())
            {
                item.Add();
                return;
            }
        }
        itemToAdd.Add(quantity - 1);
        collectedCollectables.Add(itemToAdd);
    }
}

