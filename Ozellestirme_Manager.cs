using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kutuphane;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using TMPro;

public class Ozellestirme_Manager : MonoBehaviour
{
    [Header("----------ModelAyarlari")]
    [SerializeField] private GameObject[] TopAtarlar;
    [SerializeField] private GameObject[] Kovalar;

    [Header("----------TopAyarlari")]
    [SerializeField] private GameObject[] Toplar;
    
    public TextMeshProUGUI[] TextObjeler;
    public Text[] PuanTextleri;
    public Text ParaText;
    BellekYonetimi _BellekYonetimi = new BellekYonetimi();//Hazırda top seçilimi anlamak için örnekliyoruz
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public Button[] TopButon;
    public Button[] KovaButon;//PlatformButon
    public Button[] TopAtarButon;
    public Button[] AnaPanelButonlar;
    public GameObject[] AnaPaneller;
    public GameObject[] CheckImageforBalls;
    public GameObject[] CheckImageforKova;//Platform
    public GameObject[] CheckImageforTopAtar;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    int TopIndexi = -1;

    [Header("Anahtarlar")]
    bool paraMenuAnahtar=true;
    int TopCheckindex;
    int KovaCheckindex;//Platform
    int TopAtarCheckindex;
    
    void Start()
    {   
        _BellekYonetimi.KontrolEtveTanimla();
        ParaText.text = _BellekYonetimi.VeriOku_i("Puan").ToString();
        _VeriYonetim.IlkKurulumItemOlusturma(_ItemBilgileri);
        _VeriYonetim.Load();
        _ItemBilgileri = _VeriYonetim.ListeyiAktar();
        
        TopCheckindex = _BellekYonetimi.VeriOku_i("AktifTop");
        KovaCheckindex = _BellekYonetimi.VeriOku_i("AktifKova")-6;
        TopAtarCheckindex = _BellekYonetimi.VeriOku_i("AktifTopAtar")-12;

        DilKontrol();
        ItemleriKontrolEt();
        TopAyarla();
    }

    void Update()
    {
        if(paraMenuAnahtar)
        {
            ParaText.text = _BellekYonetimi.VeriOku_i("Puan").ToString();
            paraMenuAnahtar=!paraMenuAnahtar;
        }
    }
    
    public void Top_Butonlar(int TopIndex)
    {
        switch (TopIndex)
        {
            case 0:
                TopIndexi =0;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                TopButon[0].interactable =false;
                if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                TopButon[1].interactable =false;
                else
                TopButon[1].interactable =true;
                break;       
            case 1:
                TopIndexi =1;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu == true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }
                break;
            case 2:
                TopIndexi =2;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }    
                break;
            case 3:
                TopIndexi =3;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }   
                break;
            case 4:
                TopIndexi=4;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }     
                break;
            case 5:
                TopIndexi=5;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }
                break;
        }
    }

    public void Kova_Butonlar(int KovaIndex)
    {
        switch (KovaIndex)
        {
            case 6:
                TopIndexi =6;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                KovaButon[0].interactable =false;
                if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                KovaButon[1].interactable =false;
                else
                KovaButon[1].interactable =true;
                break;
            case 7:
            TopIndexi =7;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                if(_ItemBilgileri[KovaIndex].SatinAlmaDurumu ==true)
                {
                    KovaButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                    KovaButon[1].interactable =false;
                    else
                    KovaButon[1].interactable= true;
                }
                else
                {
                    KovaButon[0].interactable= true;
                    KovaButon[1].interactable= false;
                }
                break;
            case 8:
            TopIndexi =8;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                if(_ItemBilgileri[KovaIndex].SatinAlmaDurumu ==true)
                {
                    KovaButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                    KovaButon[1].interactable =false;
                    else
                    KovaButon[1].interactable= true;
                }
                else
                {
                    KovaButon[0].interactable= true;
                    KovaButon[1].interactable= false;
                }
                break;
            case 9:
            TopIndexi =9;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                if(_ItemBilgileri[KovaIndex].SatinAlmaDurumu ==true)
                {
                    KovaButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                    KovaButon[1].interactable =false;
                    else
                    KovaButon[1].interactable= true;
                }
                else
                {
                    KovaButon[0].interactable= true;
                    KovaButon[1].interactable= false;
                }
                if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                KovaButon[1].interactable =false;
                break;
            case 10:
            TopIndexi =10;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                if(_ItemBilgileri[KovaIndex].SatinAlmaDurumu ==true)
                {
                    KovaButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                    KovaButon[1].interactable =false;
                    else
                    KovaButon[1].interactable= true;
                }
                else
                {
                    KovaButon[0].interactable= true;
                    KovaButon[1].interactable= false;
                }
                break;
            case 11:
            TopIndexi =11;
                PuanTextleri[1].text = _ItemBilgileri[KovaIndex].Puan.ToString();
                if(_ItemBilgileri[KovaIndex].SatinAlmaDurumu ==true)
                {
                    KovaButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifKova")==TopIndexi)
                    KovaButon[1].interactable =false;
                    else
                    KovaButon[1].interactable= true;
                }
                else
                {
                    KovaButon[0].interactable= true;
                    KovaButon[1].interactable= false;
                }
                break;
        }
    }
    
    public void TopAtar_Butonlar(int TopAtarIndex)
    {
        switch (TopAtarIndex)
        {
            case 12:
                TopIndexi =12;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                TopAtarButon[0].interactable =false;
                if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                TopAtarButon[1].interactable =false;
                else
                TopAtarButon[1].interactable =true;
                break;
            case 13:
            TopIndexi =13;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                if(_ItemBilgileri[TopAtarIndex].SatinAlmaDurumu ==true)
                {
                    TopAtarButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                    TopAtarButon[1].interactable =false;
                    else
                    TopAtarButon[1].interactable= true;
                }
                else
                {
                    TopAtarButon[0].interactable= true;
                    TopAtarButon[1].interactable= false;
                }      
                break;
            case 14:
            TopIndexi =14;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                if(_ItemBilgileri[TopAtarIndex].SatinAlmaDurumu ==true)
                {
                    TopAtarButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                    TopAtarButon[1].interactable =false;
                    else
                    TopAtarButon[1].interactable= true;
                }
                else
                {
                    TopAtarButon[0].interactable= true;
                    TopAtarButon[1].interactable= false;
                }      
                break;
            case 15:
            TopIndexi =15;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                if(_ItemBilgileri[TopAtarIndex].SatinAlmaDurumu ==true)
                {
                    TopAtarButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                    TopAtarButon[1].interactable =false;
                    else
                    TopAtarButon[1].interactable= true;
                }
                else
                {
                    TopAtarButon[0].interactable= true;
                    TopAtarButon[1].interactable= false;
                }
                if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                TopAtarButon[1].interactable =false;
                break;
            case 16:
            TopIndexi =16;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                if(_ItemBilgileri[TopAtarIndex].SatinAlmaDurumu ==true)
                {
                    TopAtarButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                    TopAtarButon[1].interactable =false;
                    else
                    TopAtarButon[1].interactable= true;
                }
                else
                {
                    TopAtarButon[0].interactable= true;
                    TopAtarButon[1].interactable= false;
                }
                break;
            case 17:
            TopIndexi =17;
                PuanTextleri[2].text = _ItemBilgileri[TopAtarIndex].Puan.ToString();
                if(_ItemBilgileri[TopAtarIndex].SatinAlmaDurumu ==true)
                {
                    TopAtarButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTopAtar")==TopIndexi)
                    TopAtarButon[1].interactable =false;
                    else
                    TopAtarButon[1].interactable= true;
                }
                else
                {
                    TopAtarButon[0].interactable= true;
                    TopAtarButon[1].interactable= false;
                }
                break;
        }
    }
    public void AnaPanel_Butonlar(string Gorev)
    {
        switch (Gorev)
        {
            case "Toplar":
                CheckImageforBalls[TopCheckindex].SetActive(true);
                AnaPaneller[0].SetActive(true);
                AnaPaneller[1].SetActive(false);
                AnaPaneller[2].SetActive(false);
                AnaPanelButonlar[0].interactable = true;
                AnaPanelButonlar[1].interactable = false;
                AnaPanelButonlar[2].interactable = true;
                TopButon[0].interactable= false; 
                TopButon[1].interactable= false;
                int a = 0;
                PuanTextleri[0].text = a.ToString();
                break;
            case "Kova":      
                CheckImageforKova[KovaCheckindex].SetActive(true);
                AnaPaneller[0].SetActive(false);
                AnaPaneller[1].SetActive(true);
                AnaPaneller[2].SetActive(false);
                AnaPanelButonlar[0].interactable = false;
                AnaPanelButonlar[1].interactable = true;
                AnaPanelButonlar[2].interactable = true;      
                KovaButon[0].interactable= false; 
                KovaButon[1].interactable= false;
                int b = 0;
                PuanTextleri[1].text = b.ToString();
                break;
            case "TopAtar":
                CheckImageforTopAtar[TopAtarCheckindex].SetActive(true);
                AnaPaneller[0].SetActive(false);
                AnaPaneller[1].SetActive(false);
                AnaPaneller[2].SetActive(true);
                AnaPanelButonlar[0].interactable = true;
                AnaPanelButonlar[1].interactable = true;
                AnaPanelButonlar[2].interactable = false;   
                TopAtarButon[0].interactable= false; 
                TopAtarButon[1].interactable= false;
                int c = 0;
                PuanTextleri[2].text = c.ToString();
                break;
        }
    }

    public void AnaPanelKapatmaButonlari(string kapama)
    {
        switch(kapama)
        {
            case "Toplar":
            AnaPaneller[0].SetActive(false);
            AnaPanelButonlar[1].interactable = true;
            break;
            
            case "Kova":
            AnaPaneller[1].SetActive(false);
            AnaPanelButonlar[0].interactable = true;
            break;
           
            case "TopAtar":
            AnaPaneller[2].SetActive(false);
            AnaPanelButonlar[2].interactable = true;
            break;
        }
    }

     public void TopSatinAl()
    {
        if(_ItemBilgileri[TopIndexi].SatinAlmaDurumu == false)
        {
            if(_BellekYonetimi.VeriOku_i("Puan")>=_ItemBilgileri[TopIndexi].Puan )
            {
                _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[TopIndexi].Puan);
                _ItemBilgileri[TopIndexi].SatinAlmaDurumu = true;
                _VeriYonetim.Save(_ItemBilgileri);
                paraMenuAnahtar=true;
                TopButon[1].interactable= true;
                TopButon[0].interactable= false;
            }     
        }
        else
        TopButon[1].interactable = false;    
    }

    public void KovaSatinAl()
    {
        if(_ItemBilgileri[TopIndexi].SatinAlmaDurumu ==false)
        {
            if(_BellekYonetimi.VeriOku_i("Puan")>=_ItemBilgileri[TopIndexi].Puan )
            {
                _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[TopIndexi].Puan);
                _ItemBilgileri[TopIndexi].SatinAlmaDurumu = true;
                _VeriYonetim.Save(_ItemBilgileri);
                paraMenuAnahtar=true;
                KovaButon[1].interactable= true;
                KovaButon[0].interactable= false;
            }   
        } 
        else
        KovaButon[1].interactable = false;  
    }

    public void TopAtarSatinAl()
    {
        if(_ItemBilgileri[TopIndexi].SatinAlmaDurumu ==false)
        {
            if(_BellekYonetimi.VeriOku_i("Puan")>=_ItemBilgileri[TopIndexi].Puan )
            {
                _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[TopIndexi].Puan);
                _ItemBilgileri[TopIndexi].SatinAlmaDurumu = true;
                _VeriYonetim.Save(_ItemBilgileri);
                paraMenuAnahtar=true;
                TopAtarButon[1].interactable= true;
                TopAtarButon[0].interactable= false;
            }   
        } 
        else
        TopAtarButon[1].interactable = false;  
    }
     public void TopKaydetme()
    {
        int eskiTop = _BellekYonetimi.VeriOku_i("AktifTop");
        Toplar[eskiTop].SetActive(false);

        _BellekYonetimi.VeriKaydet_int("AktifTop", TopIndexi);
        TopButon[1].interactable= false;
        
        int yeniTop = _BellekYonetimi.VeriOku_i("AktifTop");
        Toplar[yeniTop].SetActive(true);

        CheckImageforBalls[TopCheckindex].SetActive(false);
        TopCheckindex = _BellekYonetimi.VeriOku_i("AktifTop");
        CheckImageforBalls[TopCheckindex].SetActive(true);    
    }
    
    public void KovaKaydetme()
    {
        int eskiKova = _BellekYonetimi.VeriOku_i("AktifKova");
        Kovalar[eskiKova-6].SetActive(false); 

        _BellekYonetimi.VeriKaydet_int("AktifKova", TopIndexi);
        KovaButon[1].interactable = false;

        int yeniKova = _BellekYonetimi.VeriOku_i("AktifKova");
        Kovalar[yeniKova-6].SetActive(true); 
        
        CheckImageforKova[KovaCheckindex].SetActive(false);
        KovaCheckindex = _BellekYonetimi.VeriOku_i("AktifKova")-6;
        CheckImageforKova[KovaCheckindex].SetActive(true);

    }
    public void TopAtarKaydetme()
    {
        
        int eskiTopAtar = _BellekYonetimi.VeriOku_i("AktifTopAtar");
        TopAtarlar[eskiTopAtar-12].SetActive(false); 

        _BellekYonetimi.VeriKaydet_int("AktifTopAtar", TopIndexi);
        KovaButon[1].interactable = false;

        int yeniTopAtar = _BellekYonetimi.VeriOku_i("AktifTopAtar");
        TopAtarlar[yeniTopAtar-12].SetActive(true);

        CheckImageforTopAtar[TopAtarCheckindex].SetActive(false);
        TopAtarCheckindex = _BellekYonetimi.VeriOku_i("AktifTopAtar")-12;
        CheckImageforTopAtar[TopAtarCheckindex].SetActive(true);

    }
    
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
    
    void DilKontrol()
    {
        string dil = _BellekYonetimi.VeriOku_s("Dil");
        if(dil == "TR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin;
            }
        }
        else if(dil == "EN")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin;
            }
        }
    }
    
    public void ItemleriKontrolEt()
    {  
        TopAtarlar[_BellekYonetimi.VeriOku_i("AktifTopAtar")-12].SetActive(true); 
        Kovalar[_BellekYonetimi.VeriOku_i("AktifKova")-6].SetActive(true); 
    }

    void TopAyarla()
    {
        int sayi = _BellekYonetimi.VeriOku_i("AktifTop");
        Toplar[sayi].SetActive(true);
    }
}
