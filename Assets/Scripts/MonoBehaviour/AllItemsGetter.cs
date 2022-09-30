using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#region AllItemsGetter class

[ExecuteInEditMode]
public class AllItemsGetter : MonoBehaviour
{
    public bool HasToGetAllItems;
    public AllObtainedItems Items;
    public string Path = "Assets/Resources/Item/Accessory/";
    public string PathEnTrop = "Assets/Resources/";

    private void Update()
    {
        if (HasToGetAllItems)
        {
            Items.GetAllPossibleItems(Path, PathEnTrop);
            Debug.Log("AllItemsGetter : done.");
            HasToGetAllItems = false;
        }
    }
}

#endregion AllItemsGetter class

#region ObtainedItem structs

[System.Serializable]
public struct ObtainedItem
{
    public Item ItemObject;
    public bool IsObtained;

    public ObtainedItem(Item itemObject, bool isObtained)
    {
        ItemObject = itemObject;
        IsObtained = isObtained;
    }

    public void Obtain(bool value)
    {
        IsObtained = value;
    }
}

[System.Serializable]
public struct AllObtainedItems
{
    public List<ObtainedItem> ObtainedItems;                             //List des Hats existant

    public void SetObtained(int index)
    {
        ObtainedItems[index].Obtain(true);
    }

    public void GetAllPossibleItems(string path, string pathEnTrop)         //Fonction appelée par la class AllItemsGetter
    {
        ObtainedItems.Clear();                                                //Clear les lists

        //Remplit les lists de d'accessoires
        GetAllItemsOfType<Accessory>(path, pathEnTrop, ObtainedItems);
    }

    private void GetAllItemsOfType<type>(string path, string pathEnTrop, List<ObtainedItem> list)
    {
        //Array de strings répertoriant toutes les adresses des fichiers .asset dans le dossier à l'adresse path
        string[] allAssetsNames = Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories);

        foreach (string s in allAssetsNames)
        {
            //Retire le string pathEnTrop du string (car pas besoin de cette partie puisque le loading des assets se fera
            //dans le dossier Resources forcément)
            string resourcePath = s.Remove(0, pathEnTrop.Length);

            //Retire le .asset du string afin de rechercher juste le nom de l'asset recherché (c'est comme ça que fonctionne
            //Resources.Load())
            string assetFormat = ".asset";
            resourcePath = resourcePath.Remove(resourcePath.Length - assetFormat.Length, assetFormat.Length);

            //Charge l'asset dans une variable asset de type Accessory
            Accessory asset = Resources.Load<Accessory>(resourcePath);

            /* if (asset.GetType() == typeof(type))
             {*/
            //Si l'asset est bien de type passé en paramètre (par ex: Hat), alors l'asset est ajouté à la liste correspondante
            list.Add(new ObtainedItem(asset, false));
            //}
        }
    }
}

#endregion ObtainedItem structs