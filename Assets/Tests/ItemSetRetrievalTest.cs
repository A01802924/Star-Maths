using System.Collections;
using Assets.Scripts.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ItemSetRetrievalTest
{
    [Test]
    public void ItemSet_Get_Ship_Item_Test()
    {
        // Arrange: any ship item from the static List<Item> ShipItems ItemSet attribute
        int anyShipIndex = 0;
        string expectedName = "WILD SHIP 1";
        // Act
        Item retrievedShipItem = ItemSet.GetShipItem(anyShipIndex);
        // Assert
        // That the returned item is not null
        Assert.That(retrievedShipItem, Is.Not.Null);
        // And the returned item name matches with the asked one
        Assert.That(expectedName, Is.EqualTo(retrievedShipItem.name));
    }
    [Test]
    public void ItemSet_Get_Projectile_Item_Test()
    {
        // Arrange: any projectile item from the static List<Item> ProjectileItems ItemSet attribute
        int anyProjectileItemIndex = 1;
        string expectedName = "NEO MISSILE 1";
        // Act
        Item retrievedProjectileItem = ItemSet.GetProjectileItem(anyProjectileItemIndex);
        // Assert
        // That the returned item is not null
        Assert.That(retrievedProjectileItem, Is.Not.Null);
        // And the returned item name matches with the asked one
        Assert.That(expectedName, Is.EqualTo(retrievedProjectileItem.name));
    }
    [Test]
    public void ItemSet_Get_Trail_Item_Test()
    {
        // Arrange: any trail item from the static List<Item> TrailItems ItemSet attribute
        int anyTrailItemIndex = 2;
        string expectedName = "AQUA TRAIL 1";
        // Act
        Item retrievedTrailItem = ItemSet.GetTrailItem(anyTrailItemIndex);
        // Assert
        // That the returned item is not null
        Assert.That(retrievedTrailItem, Is.Not.Null);
        // And the returned item name matches with the asked one
        Assert.That(expectedName, Is.EqualTo(retrievedTrailItem.name));
    }
}
