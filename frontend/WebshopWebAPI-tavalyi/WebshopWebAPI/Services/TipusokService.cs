using WebshopWebAPI.Models;

namespace WebshopWebAPI.Services;

public static class TipusokService
{
    static List<Tipusok> Tipusok { get; }
    static int nextId = 7;
    static TipusokService()
    {
        Tipusok = new List<Tipusok>
        {
            new Tipusok { Id = 1, Kepek="okostelefon.jpg", Megnevezes = "Okostelefon", Leiras = "Kommunikációra, játékra, útvonaltervezésre, internetes böngészésre is használhatja őket."},
            new Tipusok { Id = 2, Kepek="okosora.jpg", Megnevezes = "Okosóra", Leiras = "Napjaink csúcskategóriás okosórái egyre több funkcióval rendelkeznek és sokban hasonlítanak is egymásra."},
            new Tipusok { Id = 3, Kepek="okostv.jpg", Megnevezes = "Okostévé", Leiras = "Egy új televízió vásárlása mindenki számára nagy kiadást jelent, így ezt a döntést érdemes alaposan átgondolni."},
            new Tipusok { Id = 4, Kepek="vr.jpg", Megnevezes = "VR szemüveg", Leiras = "A hihetetlen és csodálatos szórakozáshoz a belépőt csak a 3D VR szemüveg felhelyezése után kaphatod meg. Ezután rögtön kiélesednek az érzékeid, és egy virtuális világ fejlett szimulációjában találod magad. A játékos szórakozás mellett kipróbálhatsz fejlesztő alkalmazásokat, de filmet is vetíthetsz és a 3D modelleket is könnyebben áttekintheted."},
            new Tipusok { Id = 5, Kepek="fules.jpg", Megnevezes = "Fülhallgató", Leiras = "Legtöbben minden nap használunk kiegészítőket készülékeinkhez. Utazáskor zenét hallgatunk, vagy videót nézünk táblagépen, laptopon vagy telefonon. A fülhallgató és fejhallgató több mint pusztán tartozék - gyakorlatilag szórakoztatásunk szerves részévé vált. "},
            new Tipusok { Id = 6, Kepek="proj.jpg", Megnevezes = "Hangprojektor", Leiras = "Egy hangprojektor, soundbar, sound bar vagy media bar egy egyfajta hangszóró, mely egy széles burkolatból szól.  Sokkal szélesebb mint amilyen magas, részben akusztikai okokból, részben pedig azért, mert könnyen szerelhető egy kijelző alá vagy fölé, pl. egy számítógép monitora fölé, illetve egy televízió vagy egy házimozi képernyője alá. Alapvetően egy hangprojektor kabinetben több hangszóró kerül elhelyezésre, amely segít térhatású vagy sztereó hatást létrehozni."},
        };
    }

    public static List<Tipusok> GetAll() => Tipusok;

    public static Tipusok? Get(int id) => Tipusok.FirstOrDefault(p => p.Id == id);

    public static void Add(Tipusok tipus)
    {
        tipus.Id = nextId++;
        Tipusok.Add(tipus);
    }

    public static void Delete(int id)
    {
        var tipus = Get(id);
        if(tipus is null)
            return;

        Tipusok.Remove(tipus);
    }

    public static void Update(Tipusok tipus)
    {
        var index = Tipusok.FindIndex(p => p.Id == tipus.Id);
        if(index == -1)
            return;

        Tipusok[index] = tipus;
    }
}