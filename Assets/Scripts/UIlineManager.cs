using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIlineManager : MonoBehaviour
{
    public GameObject constellationViewer;

    bool obj = false;
    GameObject viewer;
    // Start is called before the first frame update
    void Start()
    {
        viewer = GameObject.Find("ConstellationViewer");
    }
    void Update()
    {
        
    }
    public void Viewer() // 전체 별자리
    {
        if (!obj)
        {
            constellationViewer.SetActive(true);
            obj = true;
        }
        else
        {
            constellationViewer.SetActive(false);
            obj = false;
        }
    }
    public void NorthernLine()
    {

    }
    public void Andromeda()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject andromeda = cv.andromeda;

        if (!obj)
        {
            andromeda.SetActive(true);
            obj = true;
        }
        else
        {
            andromeda.SetActive(false);
            obj = false;
        }
    } // 안드로메다자리
    public void Antila() // 공기펌프자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject antlia = cv.antlia;

        if (!obj)
        {
            antlia.SetActive(true);
            obj = true;
        }
        else
        {
            antlia.SetActive(false);
            obj = false;
        }
    }
    public void Apus() // 극락조자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject apus = cv.apus;

        if (!obj)
        {
            apus.SetActive(true);
            obj = true;
        }
        else
        {
            apus.SetActive(false);
            obj = false;
        }
    }
    public void Aquila()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject aquila = cv.aquila;

        if (!obj)
        {
            aquila.SetActive(true);
            obj = true;
        }
        else
        {
            aquila.SetActive(false);
            obj = false;
        }
    } // 독수리자리
    public void Aquarius() // 물병자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject aquarius = cv.aquarius;

        if (!obj)
        {
            aquarius.SetActive(true);
            obj = true;
        }
        else
        {
            aquarius.SetActive(false);
            obj = false;
        }
    }
    public void Ara() // 제단자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject ara = cv.ara;

        if (!obj)
        {
            ara.SetActive(true);
            obj = true;
        }
        else
        {
            ara.SetActive(false);
            obj = false;
        }
    }
    public void Aries() // 양자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject aries = cv.aries;

        if (!obj)
        {
            aries.SetActive(true);
            obj = true;
        }
        else
        {
            aries.SetActive(false);
            obj = false;
        }
    }
    public void Auriga()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject auriga = cv.auriga;

        if (!obj)
        {
            auriga.SetActive(true);
            obj = true;
        }
        else
        {
            auriga.SetActive(false);
            obj = false;
        }
    } // 마차부자리
    public void Bootes()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject bootes = cv.bootes;

        if (!obj)
        {
            bootes.SetActive(true);
            obj = true;
        }
        else
        {
            bootes.SetActive(false);
            obj = false;
        }
    } // 목동자리
    public void Caelum() // 조각칼자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject caelum = cv.caelum;

        if (!obj)
        {
            caelum.SetActive(true);
            obj = true;
        }
        else
        {
            caelum.SetActive(false);
            obj = false;
        }
    }
    public void Camelopardalis() // 기린자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject camelopardalis = cv.camelopardalis;

        if (!obj)
        {
            camelopardalis.SetActive(true);
            obj = true;
        }
        else
        {
            camelopardalis.SetActive(false);
            obj = false;
        }
    }
    public void Cancer() // 게자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject cancer = cv.cancer;

        if (!obj)
        {
            cancer.SetActive(true);
            obj = true;
        }
        else
        {
            cancer.SetActive(false);
            obj = false;
        }
    }
    public void CanisMajor()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject canismajor = cv.canismajor;

        if (!obj)
        {
            canismajor.SetActive(true);
            obj = true;
        }
        else
        {
            canismajor.SetActive(false);
            obj = false;
        }
    } // 큰개자리
    public void CanisMinor()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject canisminor = cv.canisminor;

        if (!obj)
        {
            canisminor.SetActive(true);
            obj = true;
        }
        else
        {
            canisminor.SetActive(false);
            obj = false;
        }
    } // 작은개자리
    public void Capricornus()// 염소자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject capricornus = cv.capricornus;

        if (!obj)
        {
            capricornus.SetActive(true);
            obj = true;
        }
        else
        {
            capricornus.SetActive(false);
            obj = false;
        }
    }
    public void Carina()// 용골자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject carina = cv.carina;

        if (!obj)
        {
            carina.SetActive(true);
            obj = true;
        }
        else
        {
            carina.SetActive(false);
            obj = false;
        }
    }
    public void Cassiopeia()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject cassiopeia = cv.cassiopeia;

        if (!obj)
        {
            cassiopeia.SetActive(true);
            obj = true;
        }
        else
        {
            cassiopeia.SetActive(false);
            obj = false;
        }
    } // 카시오페이아자리
    public void Centaurus()// 센타우루스자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject centaurus = cv.centaurus;

        if (!obj)
        {
            centaurus.SetActive(true);
            obj = true;
        }
        else
        {
            centaurus.SetActive(false);
            obj = false;
        }
    }
    public void Cepheus()// 세페우스자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject cepheus = cv.cepheus;

        if (!obj)
        {
            cepheus.SetActive(true);
            obj = true;
        }
        else
        {
            cepheus.SetActive(false);
            obj = false;
        }
    }
    public void Cetus()// 고래자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject cetus = cv.cetus;

        if (!obj)
        {
            cetus.SetActive(true);
            obj = true;
        }
        else
        {
            cetus.SetActive(false);
            obj = false;
        }
    }
    public void Chamaeleon()// 카멜레온자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject chamaeleon = cv.chamaeleon;

        if (!obj)
        {
            chamaeleon.SetActive(true);
            obj = true;
        }
        else
        {
            chamaeleon.SetActive(false);
            obj = false;
        }
    }
    public void Circinus()// 컴퍼스자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject circinus = cv.circinus;

        if (!obj)
        {
            circinus.SetActive(true);
            obj = true;
        }
        else
        {
            circinus.SetActive(false);
            obj = false;
        }
    }
    public void Columba()// 비둘기자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject columba = cv.columba;

        if (!obj)
        {
            columba.SetActive(true);
            obj = true;
        }
        else
        {
            columba.SetActive(false);
            obj = false;
        }
    }
    public void ComaBerenices()// 머리털자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject comaBerenices = cv.comaberenices;

        if (!obj)
        {
            comaBerenices.SetActive(true);
            obj = true;
        }
        else
        {
            comaBerenices.SetActive(false);
            obj = false;
        }
    }
    public void CoronaAustralis()// 남쪽왕관자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject coronaAustralis = cv.coronaaustralis;

        if (!obj)
        {
            coronaAustralis.SetActive(true);
            obj = true;
        }
        else
        {
            coronaAustralis.SetActive(false);
            obj = false;
        }
    }
    public void CoronaBorealis()// 북쪽왕관자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject coronaBorealis = cv.coronaborealis;

        if (!obj)
        {
            coronaBorealis.SetActive(true);
            obj = true;
        }
        else
        {
            coronaBorealis.SetActive(false);
            obj = false;
        }
    }
    public void Corvus()//까마귀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject corvus = cv.corvus;

        if (!obj)
        {
            corvus.SetActive(true);
            obj = true;
        }
        else
        {
            corvus.SetActive(false);
            obj = false;
        }
    }
    public void Crater()//컵자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject crater = cv.crater;

        if (!obj)
        {
            crater.SetActive(true);
            obj = true;
        }
        else
        {
            crater.SetActive(false);
            obj = false;
        }
    }
    public void Crux()// 남십자자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject crux = cv.crux;

        if (!obj)
        {
            crux.SetActive(true);
            obj = true;
        }
        else
        {
            crux.SetActive(false);
            obj = false;
        }
    }
    public void Cygnus()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject cygnus = cv.cygnus;

        if (!obj)
        {
            cygnus.SetActive(true);
            obj = true;
        }
        else
        {
            cygnus.SetActive(false);
            obj = false;
        }
    } // 백조자리
    public void Delphinus()// 돌고래자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject delphinus = cv.delphinus;

        if (!obj)
        {
            delphinus.SetActive(true);
            obj = true;
        }
        else
        {
            delphinus.SetActive(false);
            obj = false;
        }
    }
    public void Dorado()// 황새치자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject dorado = cv.dorado;

        if (!obj)
        {
            dorado.SetActive(true);
            obj = true;
        }
        else
        {
            dorado.SetActive(false);
            obj = false;
        }
    }
    public void Draco()// 용자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject draco = cv.draco;

        if (!obj)
        {
            draco.SetActive(true);
            obj = true;
        }
        else
        {
            draco.SetActive(false);
            obj = false;
        }
    }
    public void Equuleus()// 조랑말자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject equuleus = cv.equuleus;

        if (!obj)
        {
            equuleus.SetActive(true);
            obj = true;
        }
        else
        {
            equuleus.SetActive(false);
            obj = false;
        }
    }
    public void Eridanus()// 에리다누스자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject eridanus = cv.eridanus;

        if (!obj)
        {
            eridanus.SetActive(true);
            obj = true;
        }
        else
        {
            eridanus.SetActive(false);
            obj = false;
        }
    }
    public void Fornax()// 화로자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject fornax = cv.fornax;

        if (!obj)
        {
            fornax.SetActive(true);
            obj = true;
        }
        else
        {
            fornax.SetActive(false);
            obj = false;
        }
    }
    public void Gemini() // 쌍둥이자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject gemini = cv.gemini;

        if (!obj)
        {
            gemini.SetActive(true);
            obj = true;
        }
        else
        {
            gemini.SetActive(false);
            obj = false;
        }
    }
    public void Grus() // 두루미자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject grus = cv.grus;

        if (!obj)
        {
            grus.SetActive(true);
            obj = true;
        }
        else
        {
            grus.SetActive(false);
            obj = false;
        }
    }
    public void Hercules() // 헤라클레스자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject hercules = cv.hercules;

        if (!obj)
        {
            hercules.SetActive(true);
            obj = true;
        }
        else
        {
            hercules.SetActive(false);
            obj = false;
        }
    }
    public void Horologium() // 시계자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject horologium = cv.horologium;

        if (!obj)
        {
            horologium.SetActive(true);
            obj = true;
        }
        else
        {
            horologium.SetActive(false);
            obj = false;
        }
    }
    public void Hydra() // 바다뱀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject hydra = cv.hydra;

        if (!obj)
        {
            hydra.SetActive(true);
            obj = true;
        }
        else
        {
            hydra.SetActive(false);
            obj = false;
        }
    }
    public void Hydrus() // 물뱀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject hydrus = cv.hydrus;

        if (!obj)
        {
            hydrus.SetActive(true);
            obj = true;
        }
        else
        {
            hydrus.SetActive(false);
            obj = false;
        }
    }
    public void Indus() // 인디언자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject indus = cv.indus;

        if (!obj)
        {
            indus.SetActive(true);
            obj = true;
        }
        else
        {
            indus.SetActive(false);
            obj = false;
        }
    }
    public void Lacerta() // 도마뱀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject lacerta = cv.lacerta;

        if (!obj)
        {
            lacerta.SetActive(true);
            obj = true;
        }
        else
        {
            lacerta.SetActive(false);
            obj = false;
        }
    }
    public void Leo() // 사자자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject leo = cv.leo;

        if (!obj)
        {
            leo.SetActive(true);
            obj = true;
        }
        else
        {
            leo.SetActive(false);
            obj = false;
        }
    }
    public void LeoMinor() // 작은사자자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject leominor = cv.leominor;

        if (!obj)
        {
            leominor.SetActive(true);
            obj = true;
        }
        else
        {
            leominor.SetActive(false);
            obj = false;
        }
    }
    public void Lepus() // 토끼자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject lepus = cv.lepus;

        if (!obj)
        {
            lepus.SetActive(true);
            obj = true;
        }
        else
        {
            lepus.SetActive(false);
            obj = false;
        }
    }
    public void Libra() // 천칭자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject libra = cv.libra;

        if (!obj)
        {
            libra.SetActive(true);
            obj = true;
        }
        else
        {
            libra.SetActive(false);
            obj = false;
        }
    }
    public void Lupus() // 이리자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject lupus = cv.lupus;

        if (!obj)
        {
            lupus.SetActive(true);
            obj = true;
        }
        else
        {
            lupus.SetActive(false);
            obj = false;
        }
    }
    public void Lynx() // 살쾡이자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject lynx = cv.lynx;

        if (!obj)
        {
            lynx.SetActive(true);
            obj = true;
        }
        else
        {
            lynx.SetActive(false);
            obj = false;
        }
    }
    public void Lyra()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject lyra = cv.lyra;

        if (!obj)
        {
            lyra.SetActive(true);
            obj = true;
        }
        else
        {
            lyra.SetActive(false);
            obj = false;
        }
    } // 거문고자리
    public void Mensa() // 테이블산자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject mensa = cv.mensa;

        if (!obj)
        {
            mensa.SetActive(true);
            obj = true;
        }
        else
        {
            mensa.SetActive(false);
            obj = false;
        }
    }
    public void Microscopium() // 현미경자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject microscopium = cv.microscopium;

        if (!obj)
        {
            microscopium.SetActive(true);
            obj = true;
        }
        else
        {
            microscopium.SetActive(false);
            obj = false;
        }
    }
    public void Monoceros() // 외뿔소자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject monoceros = cv.monoceros;

        if (!obj)
        {
            monoceros.SetActive(true);
            obj = true;
        }
        else
        {
            monoceros.SetActive(false);
            obj = false;
        }
    }
    public void Musca() // 파리자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject musca = cv.musca;

        if (!obj)
        {
            musca.SetActive(true);
            obj = true;
        }
        else
        {
            musca.SetActive(false);
            obj = false;
        }
    }
    public void Norma() // 직각자자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject norma = cv.norma;

        if (!obj)
        {
            norma.SetActive(true);
            obj = true;
        }
        else
        {
            norma.SetActive(false);
            obj = false;
        }
    }
    public void Octans() // 팔분의자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject octans = cv.octans;

        if (!obj)
        {
            octans.SetActive(true);
            obj = true;
        }
        else
        {
            octans.SetActive(false);
            obj = false;
        }
    }
    public void Ophiuchus() // 뱀주인자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject ophiuchus = cv.ophiuchus;

        if (!obj)
        {
            ophiuchus.SetActive(true);
            obj = true;
        }
        else
        {
            ophiuchus.SetActive(false);
            obj = false;
        }
    }
    public void Orion()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject orion = cv.orion;

        if (!obj)
        {
            orion.SetActive(true);
            obj = true;
        }
        else
        {
            orion.SetActive(false);
            obj = false;
        }
    } // 오리온자리
    public void Pavo() // 공작자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject pavo = cv.pavo;

        if (!obj)
        {
            pavo.SetActive(true);
            obj = true;
        }
        else
        {
            pavo.SetActive(false);
            obj = false;
        }
    }
    public void Pegasus()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject pegasus = cv.pegasus;

        if (!obj)
        {
            pegasus.SetActive(true);
            obj = true;
        }
        else
        {
            pegasus.SetActive(false);
            obj = false;
        }
    } // 페가수스자리
    public void Perseus()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject perseus = cv.perseus;

        if (!obj)
        {
            perseus.SetActive(true);
            obj = true;
        }
        else
        {
            perseus.SetActive(false);
            obj = false;
        }
    } // 페르세우스자리
    public void Phoenix() // 불사조자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject phoenix = cv.phoenix;

        if (!obj)
        {
            phoenix.SetActive(true);
            obj = true;
        }
        else
        {
            phoenix.SetActive(false);
            obj = false;
        }
    }
    public void Pictor() // 화가자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject pictor = cv.pictor;

        if (!obj)
        {
            pictor.SetActive(true);
            obj = true;
        }
        else
        {
            pictor.SetActive(false);
            obj = false;
        }
    }
    public void Pisces() // 물고기자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject pisces = cv.pisces;

        if (!obj)
        {
            pisces.SetActive(true);
            obj = true;
        }
        else
        {
            pisces.SetActive(false);
            obj = false;
        }
    }
    public void PiscisAustrinus() // 남쪽물고기자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject piscisAustrinus = cv.piscisaustrinus;

        if (!obj)
        {
            piscisAustrinus.SetActive(true);
            obj = true;
        }
        else
        {
            piscisAustrinus.SetActive(false);
            obj = false;
        }
    }
    public void Puppis() // 고물자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject puppis = cv.puppis;

        if (!obj)
        {
            puppis.SetActive(true);
            obj = true;
        }
        else
        {
            puppis.SetActive(false);
            obj = false;
        }
    }
    public void Pyxis() // 나침반자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject pyxis = cv.pyxis;

        if (!obj)
        {
            pyxis.SetActive(true);
            obj = true;
        }
        else
        {
            pyxis.SetActive(false);
            obj = false;
        }
    }
    public void Reticulum() // 그물자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject reticulum = cv.reticulum;

        if (!obj)
        {
            reticulum.SetActive(true);
            obj = true;
        }
        else
        {
            reticulum.SetActive(false);
            obj = false;
        }
    }
    public void Sagitta() // 화살자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject sagitta = cv.sagitta;

        if (!obj)
        {
            sagitta.SetActive(true);
            obj = true;
        }
        else
        {
            sagitta.SetActive(false);
            obj = false;
        }
    }
    public void Sagittarius() // 궁수자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject sagittarius = cv.sagittarius;

        if (!obj)
        {
            sagittarius.SetActive(true);
            obj = true;
        }
        else
        {
            sagittarius.SetActive(false);
            obj = false;
        }
    }
    public void Scorpius() // 전갈자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject scorpius = cv.scorpius;

        if (!obj)
        {
            scorpius.SetActive(true);
            obj = true;
        }
        else
        {
            scorpius.SetActive(false);
            obj = false;
        }
    }
    public void Sculptor() // 조각가자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject sculptor = cv.sculptor;

        if (!obj)
        {
            sculptor.SetActive(true);
            obj = true;
        }
        else
        {
            sculptor.SetActive(false);
            obj = false;
        }
    }
    public void Scutum() // 방패자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject scutum = cv.scutum;

        if (!obj)
        {
            scutum.SetActive(true);
            obj = true;
        }
        else
        {
            scutum.SetActive(false);
            obj = false;
        }
    }
    public void Serpens() // 뱀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject serpens = cv.serpens;

        if (!obj)
        {
            serpens.SetActive(true);
            obj = true;
        }
        else
        {
            serpens.SetActive(false);
            obj = false;
        }
    }
    public void Sextans() // 육분의자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject sextans = cv.sextans;

        if (!obj)
        {
            sextans.SetActive(true);
            obj = true;
        }
        else
        {
            sextans.SetActive(false);
            obj = false;
        }
    }
    public void Taurus() // 황소자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject taurus = cv.taurus;

        if (!obj)
        {
            taurus.SetActive(true);
            obj = true;
        }
        else
        {
            taurus.SetActive(false);
            obj = false;
        }
    }
    public void Telescopium() // 망원경자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject telescopium = cv.telescopium;

        if (!obj)
        {
            telescopium.SetActive(true);
            obj = true;
        }
        else
        {
            telescopium.SetActive(false);
            obj = false;
        }
    }
    public void Triangulum() // 삼각형자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject triangulum = cv.triangulum;

        if (!obj)
        {
            triangulum.SetActive(true);
            obj = true;
        }
        else
        {
            triangulum.SetActive(false);
            obj = false;
        }
    }
    public void TriangulumAustrale() // 남쪽삼각형자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject triangulumAustrale = cv.triangulumaustrale;

        if (!obj)
        {
            triangulumAustrale.SetActive(true);
            obj = true;
        }
        else
        {
            triangulumAustrale.SetActive(false);
            obj = false;
        }
    }
    public void Tucana() // 큰부리새자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject tucana = cv.tucana;

        if (!obj)
        {
            tucana.SetActive(true);
            obj = true;
        }
        else
        {
            tucana.SetActive(false);
            obj = false;
        }
    }
    public void UrsaMajor()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject ursamajor = cv.ursamajor;

        if (!obj)
        {
            ursamajor.SetActive(true);
            obj = true;
        }
        else
        {
            ursamajor.SetActive(false);
            obj = false;
        }
    } // 큰곰자리
    public void UrsaMinor()
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject ursaminor = cv.ursaminor;

        if (!obj)
        {
            ursaminor.SetActive(true);
            obj = true;
        }
        else
        {
            ursaminor.SetActive(false);
            obj = false;
        }
    } // 작은곰자리
    public void Vela() // 돛자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject vela = cv.vela;

        if (!obj)
        {
            vela.SetActive(true);
            obj = true;
        }
        else
        {
            vela.SetActive(false);
            obj = false;
        }
    }
    public void Virgo() // 처녀자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject virgo = cv.virgo;

        if (!obj)
        {
            virgo.SetActive(true);
            obj = true;
        }
        else
        {
            virgo.SetActive(false);
            obj = false;
        }
    }
    public void Volans() // 날치자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject volans = cv.volans;

        if (!obj)
        {
            volans.SetActive(true);
            obj = true;
        }
        else
        {
            volans.SetActive(false);
            obj = false;
        }
    }
    public void Vulpecula() // 여우자리
    {
        Viewer cv = constellationViewer.GetComponent<Viewer>();

        GameObject vulpecula = cv.vulpecula;

        if (!obj)
        {
            vulpecula.SetActive(true);
            obj = true;
        }
        else
        {
            vulpecula.SetActive(false);
            obj = false;
        }
    }



    // Update is called once per frame
    
}
