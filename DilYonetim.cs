using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DilVeriYonetim
{
    public class VeriYonetimi
    {
            public void Save(List<ItemBilgileri> _ItemBilgileri)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemVerileri.gd");
                bf.Serialize(file,_ItemBilgileri);
                file.Close();
            }
            public void IlkKurulumDosyaOlusturma(List<DilVerileriAnaObje> _DilVerileri)
            {
                
                if(!File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream file = File.Create(Application.persistentDataPath + "/DilVerileri.gd");
                        bf.Serialize(file, _DilVerileri);
                        file.Close();
                    }
                
            }
            public void IlkKurulumDilOlusturma(List<DilVerileriAnaObje> _DilVerileri)
            {
                if(!File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream file = File.Create(Application.persistentDataPath + "/DilVerileri.gd");
                        bf.Serialize(file, _DilVerileri);
                        file.Close();
                    }
            }
        
        List<DilVerileriAnaObje> _DilVerileriicListe;

        public void Dil_Load()
        {
            if(File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
            {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DilVerileri.gd",FileMode.Open);
            _DilVerileriicListe = (List<DilVerileriAnaObje>)bf.Deserialize(file);
            file.Close();
            
            }
        }

        public List<DilVerileriAnaObje> DilVerileriListeyiAktar()
        {
            return _DilVerileriicListe;
        }
    }

    //------------------------------------------------DİL YÖNETİMİ

    [Serializable]

    public class DilVerileriAnaObje
    {
        
        public List<DilVerileri_TR> _DilVerileri_TR = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_EN = new List<DilVerileri_TR>();
        
        
    }
    [Serializable]
    public class DilVerileri_TR
    {
        public string Metin;
    }
