using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    public GameObject andromeda;
    public GameObject antlia;
    public GameObject apus;
    public GameObject aquarius;
    public GameObject aquila;
    public GameObject ara;
    public GameObject aries;
    public GameObject auriga;
    public GameObject bootes;
    public GameObject caelum;
    public GameObject camelopardalis;
    public GameObject cancer;
    public GameObject canesvenatici;
    public GameObject canismajor;
    public GameObject canisminor;
    public GameObject capricornus;
    public GameObject carina;
    public GameObject cassiopeia;
    public GameObject centaurus;
    public GameObject cepheus;
    public GameObject cetus;
    public GameObject chamaeleon;
    public GameObject circinus;
    public GameObject columba;
    public GameObject comaberenices;
    public GameObject coronaaustralis;
    public GameObject coronaborealis;
    public GameObject corvus;
    public GameObject crater;
    public GameObject crux;
    public GameObject cygnus;
    public GameObject delphinus;
    public GameObject dorado;
    public GameObject draco;
    public GameObject equuleus;
    public GameObject eridanus;
    public GameObject fornax;
    public GameObject gemini;
    public GameObject grus;
    public GameObject hercules;
    public GameObject horologium;
    public GameObject hydra;
    public GameObject hydrus;
    public GameObject indus;
    public GameObject lacerta;
    public GameObject leo;
    public GameObject leominor;
    public GameObject lepus;
    public GameObject libra;
    public GameObject lupus;
    public GameObject lynx;
    public GameObject lyra;
    public GameObject mensa;
    public GameObject microscopium;
    public GameObject monoceros;
    public GameObject musca;
    public GameObject norma;
    public GameObject octans;
    public GameObject ophiuchus;
    public GameObject orion;
    public GameObject pavo;
    public GameObject pegasus;
    public GameObject perseus;
    public GameObject phoenix;
    public GameObject pictor;
    public GameObject pisces;
    public GameObject piscisaustrinus;
    public GameObject puppis;
    public GameObject pyxis;
    public GameObject reticulum;
    public GameObject sagitta;
    public GameObject sagittarius;
    public GameObject scorpius;
    public GameObject sculptor;
    public GameObject scutum;
    public GameObject serpens;
    public GameObject sextans;
    public GameObject taurus;
    public GameObject telescopium;
    public GameObject triangulum;
    public GameObject triangulumaustrale;
    public GameObject tucana;
    public GameObject ursamajor;
    public GameObject ursaminor;
    public GameObject vela;
    public GameObject virgo;
    public GameObject volans;
    public GameObject vulpecula;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        andromeda = transform.Find("Andromeda").gameObject; // 안드로메다자리
        antlia = transform.Find("Antlia").gameObject; // 공기펌프자리
        apus = transform.Find("Apus").gameObject; // 극락조자리
        aquarius = transform.Find("Aquarius").gameObject; // 물병자리
        aquila = transform.Find("Aquila").gameObject; // 독수리자리
        ara = transform.Find("Ara").gameObject; // 제단자리
        aries = transform.Find("Aries").gameObject; // 양자리
        auriga = transform.Find("Auriga").gameObject; // 마차부자리
        bootes = transform.Find("Bootes").gameObject; // 목동자리
        caelum = transform.Find("Caelum").gameObject; // 조각칼자리
        camelopardalis = transform.Find("Camelopardalis").gameObject; // 기린자리
        cancer = transform.Find("Cancer").gameObject; // 게자리
        canesvenatici = transform.Find("Canes Venatici").gameObject; // 사냥개자리
        canismajor = transform.Find("Canis Major").gameObject; // 큰개자리
        canisminor = transform.Find("Canis Minor").gameObject; // 작은개자리
        capricornus = transform.Find("Capricornus").gameObject; // 염소자리
        carina = transform.Find("Carina").gameObject; // 용골자리
        cassiopeia = transform.Find("Cassiopeia").gameObject; // 카시오페이아자리
        centaurus = transform.Find("Centaurus").gameObject; // 센타우루스자리
        cepheus = transform.Find("Cepheus").gameObject; // 세페우스자리
        cetus = transform.Find("Cetus").gameObject; // 고래자리
        chamaeleon = transform.Find("Chamaeleon").gameObject; // 카멜레온자리
        circinus = transform.Find("Circinus").gameObject; // 컴퍼스자리
        columba = transform.Find("Columba").gameObject; // 비둘기자리
        comaberenices = transform.Find("Coma Berenices").gameObject; // 머리털자리
        coronaaustralis = transform.Find("Corona Australis").gameObject; // 남쪽왕관자리
        coronaborealis = transform.Find("Corona Borealis").gameObject; // 북쪽왕관자리
        corvus = transform.Find("Corvus").gameObject; // 까마귀자리
        crater = transform.Find("Crater").gameObject; // 컵자리
        crux = transform.Find("Crux").gameObject; // 남십자자리
        cygnus = transform.Find("Cygnus").gameObject; // 백조자리
        delphinus = transform.Find("Delphinus").gameObject; // 돌고래자리
        dorado = transform.Find("Dorado").gameObject; // 황새치자리
        draco = transform.Find("Draco").gameObject; // 용자리
        equuleus = transform.Find("Equuleus").gameObject; // 조랑말자리 
        eridanus = transform.Find("Eridanus").gameObject; // 에리다누스자리
        fornax = transform.Find("Fornax").gameObject; // 화로자리
        gemini = transform.Find("Gemini").gameObject; // 쌍둥이자리
        grus = transform.Find("Grus").gameObject;    // 두루미자리
        hercules = transform.Find("Hercules").gameObject;  // 헤라클레스자리
        horologium = transform.Find("Horologium").gameObject;   //시계자리
        hydra = transform.Find("Hydra").gameObject;   //바다뱀자리
        hydrus = transform.Find("Hydrus").gameObject;   //물뱀자리
        indus = transform.Find("Indus").gameObject;   //인디언자리
        lacerta = transform.Find("Lacerta").gameObject; // 도마뱀자리
        leo = transform.Find("Leo").gameObject;  // 사자자리
        leominor = transform.Find("Leo Minor").gameObject; // 작은사자자리
        lepus = transform.Find("Lepus").gameObject; // 토끼자리
        libra = transform.Find("Libra").gameObject; // 천칭자리
        lupus = transform.Find("Lupus").gameObject; // 이리자리
        lynx = transform.Find("Lynx").gameObject; // 살쾡이자리
        lyra = transform.Find("Lyra").gameObject; // 거문고자리
        mensa = transform.Find("Mensa").gameObject; // 테이블산자리
        microscopium = transform.Find("Microscopium").gameObject; // 현미경자리
        monoceros = transform.Find("Monoceros").gameObject; // 외뿔소자리
        musca = transform.Find("Musca").gameObject; // 파리자리
        norma = transform.Find("Norma").gameObject; // 직각자자리
        octans = transform.Find("Octans").gameObject; // 팔분의자리
        ophiuchus = transform.Find("Ophiuchus").gameObject; // 뱀주인자리
        orion = transform.Find("Orion").gameObject; // 오리온자리
        pavo = transform.Find("Pavo").gameObject; // 공작자리
        pegasus = transform.Find("Pegasus").gameObject; // 페가수스자리
        perseus = transform.Find("Perseus").gameObject; // 페르세우스자리
        phoenix = transform.Find("Phoenix").gameObject; // 불사조자리
        pictor = transform.Find("Pictor").gameObject; // 화가자리
        pisces = transform.Find("Pisces").gameObject; // 물고기자리
        piscisaustrinus = transform.Find("Piscis Austrinus").gameObject; // 남쪽물고기자리
        puppis = transform.Find("Puppis").gameObject; // 고물자리
        pyxis = transform.Find("Pyxis").gameObject; // 나침반자리
        reticulum = transform.Find("Reticulum").gameObject; // 그물자리
        sagitta = transform.Find("Sagitta").gameObject; // 화살자리
        sagittarius = transform.Find("Sagittarius").gameObject; // 궁수자리
        scorpius = transform.Find("Scorpius").gameObject; // 전갈자리
        sculptor = transform.Find("Sculptor").gameObject; // 조각가자리
        scutum = transform.Find("Scutum").gameObject; // 방패자리
        serpens = transform.Find("Serpens").gameObject; // 뱀자리
        sextans = transform.Find("Sextans").gameObject; // 육분의자리
        taurus = transform.Find("Taurus").gameObject; // 황소자리
        telescopium = transform.Find("Telescopium").gameObject; //망원경자리
        triangulum = transform.Find("Triangulum").gameObject; // 삼각형자리
        triangulumaustrale = transform.Find("Triangulum Australe").gameObject; // 남쪽삼각형자리
        tucana = transform.Find("Tucana").gameObject; // 큰부리새자리
        ursamajor = transform.Find("Ursa Major").gameObject; // 큰곰자리
        ursaminor = transform.Find("Ursa Minor").gameObject; // 작은곰자리
        vela = transform.Find("Vela").gameObject; // 돛자리
        virgo = transform.Find("Virgo").gameObject; // 처녀자리
        volans = transform.Find("Volans").gameObject; // 날치자리
        vulpecula = transform.Find("Vulpecula").gameObject; // 여우자리
    }
}
