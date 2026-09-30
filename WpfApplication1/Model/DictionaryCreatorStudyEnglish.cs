using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryLibrary.Model;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryCreator
    //-------------------------------------------------------------------------------------------------------------------
    public partial class DictionaryCreator
    {
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishCulinaryFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Culinary",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishCulinaryHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishAnatomyFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Anatomy",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishAnatomyHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishAppearanceFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Appearance",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishAppearanceHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishTownFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Town",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishTownHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishGrammarFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Grammar",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishGrammarHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishTreeFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Tree",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishTreeHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishHomeFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Home",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishHomeHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishAnimalsFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Animals",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishAnimalsHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishHealthFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Health",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishHealthHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishBelongingsFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Belongings",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishBelongingsHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishBelongingsHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	portion	</b></td><td>	приданное	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fortune	</b></td><td>	состояние	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stuff	</b></td><td>	вещи	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fixings	</b></td><td>	принадлежности	</td></tr>
<tr><td bgcolor=""#E9DDC8"" ><b>	furniture	</b></td><	мебель	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	aquarium	</b></td><td>	аквариум	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	armchair	</b></td><td>	кресло	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	armchair-sofa	</b></td><td>	кресло-диван	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bed	</b></td><td>	кровать	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bedside-table	</b></td><td>	тумбочка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bench	</b></td><td>	скамейка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bookcase	</b></td><td>	книжный шкаф	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	buffet	</b></td><td>	буфет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chair	</b></td><td>	стул	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cornice	</b></td><td>	карниз	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cot	</b></td><td>	кроватка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	couch	</b></td><td>	кушетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cradle	</b></td><td>	колыбель, люлька	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cuppoard	</b></td><td>	кухонный шкаф	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	curbstone	</b></td><td>	тумба	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	desk	</b></td><td>	парта	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	divan	</b></td><td>	диван	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	door	</b></td><td>	дверца	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hammock	</b></td><td>	гамак	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	jalousie	</b></td><td>	жалюзи	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	locker	</b></td><td>	комод	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	matress	</b></td><td>	матрац	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	mirror	</b></td><td>	зеркало	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pad	</b></td><td>	пуфик	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	rocker	</b></td><td>	кресло-качалка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	safe	</b></td><td>	сейф	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	screen	</b></td><td>	ширма	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	shelf	</b></td><td>	полка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	sideboard	</b></td><td>	сервант	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	sofa	</b></td><td>	софа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stool	</b></td><td>	табурет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	table	</b></td><td>	стол	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vase	</b></td><td>	ваза	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	wardrobe	</b></td><td>	гардероб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cot	</b></td><td>	кроватка детская	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dummy	</b></td><td>	соска	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nipple	</b></td><td>	соска на бутылке	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pacifier	</b></td><td>	пустышка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	rattle	</b></td><td>	погремушка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bank	</b></td><td>	банка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bolter	</b></td><td>	сито	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bottle	</b></td><td>	бутылка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	brazier	</b></td><td>	мангал	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bucket	</b></td><td>	ведро	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	butt	</b></td><td>	бочка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chopsticks	</b></td><td>	палочки для еды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	coffe-pot	</b></td><td>	кофейник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	colander	</b></td><td>	дуршлаг	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cooper	</b></td><td>	котел	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	corkscrew	</b></td><td>	штопор	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cup	</b></td><td>	чашка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dish	</b></td><td>	блюдо	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fork	</b></td><td>	вилка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	frying pan	</b></td><td>	сковорода	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	glass	</b></td><td>	стакан	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	grater	</b></td><td>	терка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	herring-dish	</b></td><td>	селедочница	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	jug	</b></td><td>	кувшин	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	kettle	</b></td><td>	чайник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	knife	</b></td><td>	нож	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ladle	</b></td><td>	ковш, половник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lid	</b></td><td>	крышка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	mug	</b></td><td>	кружка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	napkin	</b></td><td>	салфетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pepper-pot	</b></td><td>	перечница	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	plate	</b></td><td>	тарелка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pot	</b></td><td>	горшок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pressure cooker	</b></td><td>	скороварка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	salad-dish	</b></td><td>	салатник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	saucepan	</b></td><td>	кастрюля	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	saucer	</b></td><td>	блюдце	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	scoop	</b></td><td>	черпак	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	skewer	</b></td><td>	шампур	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	spoon	</b></td><td>	ложка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	support	</b></td><td>	подставка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	teapot	</b></td><td>	чайник для заварки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tea-strainer	</b></td><td>	ситечко	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thermos	</b></td><td>	термос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tin	</b></td><td>	жестяная банка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tray	</b></td><td>	поднос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	trowel	</b></td><td>	лопатка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vase	</b></td><td>	ваза	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	wine-glass	</b></td><td>	рюмка	</td></tr>
<tr><td bgcolor=""#E9DDC8"" ><b>	inventory	</b></td><	инвентарь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	air freshener	</b></td><td>	освежитель	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	basin	</b></td><td>	таз	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	besom	</b></td><td>	веник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	broom	</b></td><td>	метла	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	brush	</b></td><td>	щетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	camber-pot	</b></td><td>	горшок ночной	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clock	</b></td><td>	часы	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clothes-brush	</b></td><td>	щетка для одежды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clothes-pin	</b></td><td>	прищепка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dustpan	</b></td><td>	совок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	flasket	</b></td><td>	корзина для белья	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hanger	</b></td><td>	вешалка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hangers	</b></td><td>	плечики	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	rug	</b></td><td>	коврик	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	step-ledder	</b></td><td>	стремянка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	swap	</b></td><td>	швабра	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bulb	</b></td><td>	лампочка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	candle	</b></td><td>	свеча	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	candlestick	</b></td><td>	подсвечник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chandelier	</b></td><td>	люстра	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	flash-light	</b></td><td>	фонарик	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lamp	</b></td><td>	светильник, лампа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lamp-bracket	</b></td><td>	бра	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lantern	</b></td><td>	фонарь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	match	</b></td><td>	спичка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	night-lamp	</b></td><td>	ночник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	radiator	</b></td><td>	радиатор, батарея	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	socket	</b></td><td>	розетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stove	</b></td><td>	печь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	switch	</b></td><td>	выключатель	</td></tr>
<tr><td bgcolor=""#E9DDC8"" ><b>	furnishings	</b></td><	бытовой прибор	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blender	</b></td><td>	Блендер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bottle-opener	</b></td><td>	открывалка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	circling-irons	</b></td><td>	щипцы для волос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	coffee maker	</b></td><td>	кофеварка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	coffee-grinder	</b></td><td>	кофемолка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	combine	</b></td><td>	комбайн	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	conditioner	</b></td><td>	кондиционер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	drawing out	</b></td><td>	вытяжка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	electrolighter	</b></td><td>	электрозажигалка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fridge	</b></td><td>	холодильник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	gas-stove	</b></td><td>	плита газовая	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	geyser	</b></td><td>	колонка(водонагревательн.)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hair-drier	</b></td><td>	фен	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	immersion heater	</b></td><td>	кипятильник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	iron	</b></td><td>	утюг	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	meat grinder	</b></td><td>	мясорубка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	mixer	</b></td><td>	миксер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	oven	</b></td><td>	духовка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	player	</b></td><td>	проигрыватель	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	sewing-machine	</b></td><td>	швейная машинка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tape recorder	</b></td><td>	магнитофон	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	TV set	</b></td><td>	телевизор	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vacuum cleaner	</b></td><td>	пылесос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ventilator	</b></td><td>	вентилятор	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	video recorder	</b></td><td>	видеомагнитофон	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	Walkman	</b></td><td>	плейер	</td></tr>
<tr><td bgcolor=""#E9DDC8"" ><b>	linen	</b></td><	белье	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bed-clothes	</b></td><td>	постельное белье	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bedding	</b></td><td>	постель	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blanket	</b></td><td>	одеяло	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blanket cover	</b></td><td>	пододеяльник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	coverlet	</b></td><td>	покрывало	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	napkin	</b></td><td>	салфетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pillow	</b></td><td>	подушка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	sheet	</b></td><td>	простыня	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	swaddling band	</b></td><td>	пеленка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	table-cloth	</b></td><td>	скатерть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tea-cloth	</b></td><td>	салфетка чайная	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tea-towel	</b></td><td>	полотенце кухонное	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	towel	</b></td><td>	полотенце	</td></tr>
<tr><td bgcolor=""#E9DDC8"" ><b>	stationery	</b></td><	канцтовары	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	alidad	</b></td><td>	транспортир	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	badge	</b></td><td>	бейдж, значок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blot	</b></td><td>	клякса	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cap	</b></td><td>	колпачок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chalk	</b></td><td>	мелок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clip	</b></td><td>	зажим	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	commonplace-book	</b></td><td>	общая тетрадь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	compass	</b></td><td>	циркуль	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	copy-book	</b></td><td>	школьная тетрадь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	core	</b></td><td>	стержень	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	crayon	</b></td><td>	цветной мелок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	diary	</b></td><td>	дневник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	drawing-pad	</b></td><td>	альбом для рисования	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	drawing-pin	</b></td><td>	кнопка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eraser	</b></td><td>	ластик	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	folder	</b></td><td>	папка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	folder-file	</b></td><td>	папка-файл	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	globe	</b></td><td>	глобус	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	glue	</b></td><td>	клей	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ink	</b></td><td>	чернила	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	marker	</b></td><td>	маркер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	notebook	</b></td><td>	блокнот	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	organizer	</b></td><td>	органайзер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pad	</b></td><td>	блокнот	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pallette	</b></td><td>	палитра	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	paper clip	</b></td><td>	скрепка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pen	</b></td><td>	ручка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pencil	</b></td><td>	карандаш	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pencil-box	</b></td><td>	пенал	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pen-sharpener	</b></td><td>	точилка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	plasticine	</b></td><td>	пластилин	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	puncher	</b></td><td>	дырокол	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ruler	</b></td><td>	линейка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stapler	</b></td><td>	степлер	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stroke	</b></td><td>	штрих	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	triagle	</b></td><td>	треугольник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tweezers	</b></td><td>	пинцет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	writingbook	</b></td><td>	тетрадь	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishHealthHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	астма 							</b></td><td> 	asthma
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бедро 							</b></td><td> 	thigh
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	беременная						</b></td><td> 	pregnant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бинт 							</b></td><td> 	bandage
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бледный						</b></td><td> 	pale
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	болезнь 						</b></td><td> 	disease
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	болеутоляющее средство				</b></td><td> 	painkiller
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	боль 							</b></td><td> 	pain
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	больничный (отпуск по болезни)			</b></td><td> 	sick leave
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	больной						</b></td><td> 	ill
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бровь 							</b></td><td> 	eyebrow
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бронхит 						</b></td><td> 	bronchitis
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	в хорошей форме					</b></td><td> 	fit
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	висок 							</b></td><td> 	temple
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	волосы (волос)					</b></td><td> 	hair
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	вредный						</b></td><td> 	harmful
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	глаз 							</b></td><td> 	eye
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	глухой							</b></td><td> 	deaf
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	голова 						</b></td><td> 	head
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	горло 							</b></td><td> 	throat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	грипп 							</b></td><td> 	flu
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	грудь 							</b></td><td> 	chest
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	губа 							</b></td><td> 	lip
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	диагноз 						</b></td><td> 	diagnosis
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	доза 							</b></td><td> 	dose
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дышать						</b></td><td> 	to breathe
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	желудок 						</b></td><td> 	stomach
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	живот 							</b></td><td> 	belly
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	заболевать/заболеть 					</b></td><td> 	to fall ill 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	запястье 						</b></td><td> 	wrist
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	заразный						</b></td><td> 	infectious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	здоровый						</b></td><td> 	healthy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	здоровье 						</b></td><td> 	health
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	зуб 							</b></td><td> 	tooth
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	инсульт 						</b></td><td> 	stroke
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кожа 							</b></td><td> 	skin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	костыль 						</b></td><td> 	crutch
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кость 							</b></td><td> 	bone
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кровь 							</b></td><td> 	blood
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	курить/покурить					</b></td><td> 	to smoke
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лёгкое 						</b></td><td> 	lung
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лекарство 						</b></td><td> 	drug
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лекарство от кашля					</b></td><td> 	cough medicine
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лечение 						</b></td><td> 	treatment
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лицо 							</b></td><td> 	face
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лоб 							</b></td><td> 	forehead
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	локоть							</b></td><td> 	elbow
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	машина скорой помощи				</b></td><td> 	ambulance
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	медицина 						</b></td><td> 	medicine
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	медсестра						</b></td><td> 	nurse
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мозг 							</b></td><td> 	brain
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нарыв 							</b></td><td> 	abscess
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	насморк 						</b></td><td> 	cold
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	недееспособный (инвалид)				</b></td><td> 	disabled
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	неизлечимая болезнь				</b></td><td> 	incurable disease
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нога 							</b></td><td> 	leg
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ноготь 						</b></td><td> 	nail
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нос 							</b></td><td> 	nose
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	операция 						</b></td><td> 	 surgery
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	отдыхать/отдохнуть					</b></td><td> 	to  rest
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	отрава 						</b></td><td> 	poison
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	очки							</b></td><td> 	glasses
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	падать/упасть в обморок				</b></td><td> 	to faint
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	палец							</b></td><td> 	finger
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	палец ноги						</b></td><td> 	toe
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пах 							</b></td><td> 	groin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пациент(ка) 						</b></td><td> 	patient
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	перевязь 						</b></td><td> 	sling
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	перелом 						</b></td><td> 	fracture
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	печень 						</b></td><td> 	liver
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пластырь 						</b></td><td> 	 plaster
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	плечо 							</b></td><td> 	shoulder
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	побочное действие					</b></td><td> 	side-effect
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подбородок 						</b></td><td> 	chin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	позвоночник 						</b></td><td> 	backbone
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	порез 							</b></td><td> 	cut
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пот 							</b></td><td> 	sweat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	почка 							</b></td><td> 	kidney
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	принимать/принять лекарство			</b></td><td> 	to take medicine
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	простуда 						</b></td><td> 	cold
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	простудиться						</b></td><td> 	to catch a cold
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	прыщ 							</b></td><td> 	 pimple
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пульс 							</b></td><td> 	pulse
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пятка 							</b></td><td> 	heel
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рак 							</b></td><td> 	cancer
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	реабилитация						</b></td><td> 	rehabilitation
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рентген 						</b></td><td> 	X-ray
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ресница 						</b></td><td> 	eyelash
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рецепт (мед.) 						</b></td><td> 	prescription
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рот							</b></td><td> 	mouth
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рука 							</b></td><td> 	hand
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	сердечный приступ					</b></td><td> 	heart attack
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	сердце 						</b></td><td> 	heart
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	синяк 							</b></td><td> 	bruise
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	скелет 						</b></td><td> 	skeleton
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	скорая (помощь) 					</b></td><td> 	ambulance
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	слабый						</b></td><td> 	weak
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	слепой						</b></td><td> 	blind
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	советоваться/посоветоваться с врачом		</b></td><td> 	to consult a doctor
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	солнечный удар					</b></td><td> 	sunstroke
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	спина 							</b></td><td> 	back
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	средство 						</b></td><td> 	remedy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стопа							</b></td><td> 	foot
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	страдать 						</b></td><td> 	to suffer 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	сыпь 							</b></td><td> 	rash
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	таблетка 						</b></td><td> 	pill
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	талия 							</b></td><td> 	waist
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тело 							</b></td><td> 	body
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	термометр 						</b></td><td> 	thermometer
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	умирать/умереть					</b></td><td> 	to die
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	усы 							</b></td><td> 	moustache
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	утешать						</b></td><td> 	to console
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ухо 							</b></td><td> 	ear
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	хирургия 						</b></td><td> 	surgery
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	челюсть 						</b></td><td> 	jaw
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	череп 							</b></td><td> 	skull
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чувствовать себя хорошо				</b></td><td> 	to feel well
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шея 							</b></td><td> 	neck
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шприц 						</b></td><td> 	syringe
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шрам 							</b></td><td> 	scar
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	щека 							</b></td><td> 	cheek
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	эпидемия 						</b></td><td> 	epidemic
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	язва 							</b></td><td> 	ulcer
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	язык 							</b></td><td> 	tongue
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishAnimalsHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	аист	</b></td><td>	stork	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	акула	</b></td><td>	shark	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	антилопа	</b></td><td>	antelope	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бабочка	</b></td><td>	butterfly	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	баран	</b></td><td>	ram	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	барсук	</b></td><td>	badger	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	белка	</b></td><td>	squirrel	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	белый медведь	</b></td><td>	polar bear	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бобр	</b></td><td>	beaver	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	божья коровка	</b></td><td>	ladybird	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бык	</b></td><td>	bull	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вол, бык	</b></td><td>	ox	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	волк	</b></td><td>	wolf	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	волнистый попугайчик	</b></td><td>	budgie	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	воробей	</b></td><td>	sparrow	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ворон	</b></td><td>	raven	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ворона	</b></td><td>	crow	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гадюка	</b></td><td>	viper	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	голубь	</b></td><td>	pigeon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горилла	</b></td><td>	gorilla	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горлица	</b></td><td>	turtledove	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гриф	</b></td><td>	vulture	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гусеница	</b></td><td>	caterpillar	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гусь	</b></td><td>	goose	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дикий кабан	</b></td><td>	wild boar	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дрозд	</b></td><td>	blackbird	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дятел	</b></td><td>	woodpecker	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ёж	</b></td><td>	hedgehog	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жаворонок	</b></td><td>	lark	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жираф	</b></td><td>	giraffe	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жук	</b></td><td>	beetle	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	журавль	</b></td><td>	crane	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	заяц	</b></td><td>	hare	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	зебра	</b></td><td>	zebra	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	змея	</b></td><td>	snake	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	индюк	</b></td><td>	turkey	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	канарейка	</b></td><td>	canary	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	канюк	</b></td><td>	buzzard	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кенгуру	</b></td><td>	kangaroo	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клоп	</b></td><td>	bug	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	козел	</b></td><td>	goat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	козленок	</b></td><td>	kid	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	комар, москит	</b></td><td>	gnat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	корова	</b></td><td>	cow	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кот	</b></td><td>	cat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	котенок	</b></td><td>	kitten	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	крокодил	</b></td><td>	crocodile	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кролик	</b></td><td>	rabbit	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	крыса	</b></td><td>	rat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кузнечик	</b></td><td>	grasshopper	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кукушка	</b></td><td>	cuckoo	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	курица	</b></td><td>	hen	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	куропатка	</b></td><td>	partridge	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ласточка	</b></td><td>	swallow	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лебедь	</b></td><td>	swan	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лев	</b></td><td>	lion	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	летучая мышь	</b></td><td>	bat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лисица	</b></td><td>	fox	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лось	</b></td><td>	elk	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лошадь	</b></td><td>	horse	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лягушка	</b></td><td>	frog	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	медведь	</b></td><td>	bear	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	моль	</b></td><td>	moth	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	морская звезда	</b></td><td>	starfish	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	муравей	</b></td><td>	ant	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	муха	</b></td><td>	fly	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мышь	</b></td><td>	mouse	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	носорог	</b></td><td>	rhino	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	обезьяна	</b></td><td>	monkey	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	овца	</b></td><td>	sheep	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	олень	</b></td><td>	deer	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	орел	</b></td><td>	eagle	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	оса	</b></td><td>	wasp	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	осел	</b></td><td>	donkey	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	павлин	</b></td><td>	peacock	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	паук	</b></td><td>	spider	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	петух	</b></td><td>	cock	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пингвин	</b></td><td>	penguin	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пиявка	</b></td><td>	leech	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пони	</b></td><td>	pony	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	попугай	</b></td><td>	parrot	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	поросенок	</b></td><td>	pig	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пчела	</b></td><td>	bee	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	рысь	</b></td><td>	lynx	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	синица	</b></td><td>	titmouse	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	скорпион	</b></td><td>	scorpion	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	слон	</b></td><td>elephant</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	собака	</b></td><td>	dog	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сова	</b></td><td>	owl	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сокол	</b></td><td>	falcon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	соловей	</b></td><td>	nightingale	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сорока	</b></td><td>	magpie	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	страус	</b></td><td>	ostrich	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	таракан	</b></td><td>	cockroach	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	теленок	</b></td><td>	calf	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тетерев	</b></td><td>	heath-cock	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тигр	</b></td><td>	tiger	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тюлень	</b></td><td>	seal	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	улитка	</b></td><td>	snail	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	утенок	</b></td><td>	duckling	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	утка	</b></td><td>	duck	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фазан	</b></td><td>	pheasant	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фламинго	</b></td><td>	flamingo	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	хорёк	</b></td><td>	ferret	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	цапля	</b></td><td>	heron	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	цыпленок	</b></td><td>	chicken	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чайка	</b></td><td>	seagull	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	червь	</b></td><td>	worm	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	черепаха	</b></td><td>	tortoise	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	щенок	</b></td><td>	puppy	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ягненок	</b></td><td>	lamb	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ястреб	</b></td><td>	hawk	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ящерица	</b></td><td>	lizard	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishHomeHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	балкон 					</b></td><td>	 balcony
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бриться/побриться			</b></td><td>	 to shave
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	будильник 				</b></td><td>	 alarm clock
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ваза 					</b></td><td>	 vase
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ванна 					</b></td><td>	 bath
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ванная 				</b></td><td>	 bathroom
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ведро 					</b></td><td>	 bucket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	вставать/встать			</b></td><td>	 to get up
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	выключатель 				</b></td><td>	 switch
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	вытирать/вытереть			</b></td><td>	 to wipe 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	газон 					</b></td><td>	 lawn
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гараж 					</b></td><td>	 garage
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гардероб 				</b></td><td>	 wardrobe
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гладить/погладить			</b></td><td>	  to press
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гостиная 				</b></td><td>	 living room
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	грязный				</b></td><td>	 dirty
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	грязь 					</b></td><td>	 mud
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дверь 					</b></td><td>	 door
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дом 					</b></td><td>	 house
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дома					</b></td><td>	 at home
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	духовка 				</b></td><td>	 oven
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	душ 					</b></td><td>	 shower
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	забор 					</b></td><td>	 fence
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	замок 					</b></td><td>	 lock
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	занавеска 				</b></td><td>	 curtain
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	зеркало 				</b></td><td>	 mirror
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кабинет 				</b></td><td>	 study
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	камин 					</b></td><td>	 fireplace
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	картина 				</b></td><td>	 picture
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	квартира 				</b></td><td>	 apartment
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ключ 					</b></td><td>	 key
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	книжный шкаф				</b></td><td>	 bookcase
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ковёр	</b></td><td>	carpet			
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	комната 				</b></td><td>	 room
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	красить/покрасить			</b></td><td>	 to paint
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кресло 					</b></td><td>	 armchair
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кровать 				</b></td><td>	 bed
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	крыша 					</b></td><td>	 roof
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кухня 					</b></td><td>	 kitchen
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лестница 				</b></td><td>	 stairs
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ложиться/лечь				</b></td><td>	 to lie down
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ложиться/лечь спать			</b></td><td>	 to go to bed
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мебель 				</b></td><td>	 furniture
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	метла 					</b></td><td>	 broom
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	микроволновая печь			</b></td><td>	 oven
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	морозильник 				</b></td><td>	 freezer
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мусорный ящик			</b></td><td>	 dustbin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мыло 					</b></td><td>	 soap
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мыться/вымыться			</b></td><td>	 to wash 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	на улице				</b></td><td>	 outside, outdoors
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нагреватель 				</b></td><td>	 heater
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ножницы 				</b></td><td>	 scissors
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	обои 					</b></td><td>	 wallpaper
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	одеяло 				</b></td><td>	 blanket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	окно 					</b></td><td>	 window
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	открывать/открыть			</b></td><td>	 to open
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	письменный стол			</b></td><td>	  desk
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	плита 					</b></td><td>	 cooker
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подоконник 				</b></td><td>	 ledge
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подушка 				</b></td><td>	 pillow
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пол 					</b></td><td>	 floor
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	полка 					</b></td><td>	 shelf
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	полотенце 				</b></td><td>	 towel
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	посудомоечная машина		</b></td><td>	 dishwasher
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	потолок 				</b></td><td>	 ceiling
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	просторный				</b></td><td>	 spacious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	простыня 				</b></td><td>	 sheet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	просыпаться				</b></td><td>	 to wake up
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пылесос 				</b></td><td>	 vacuum cleaner
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пылесосить				</b></td><td>	 to vacuum
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пыль 					</b></td><td>	 dust
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пыльный				</b></td><td>	 dusty
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	радиатор 				</b></td><td>	 radiator
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	радио					</b></td><td>	 radio
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	раковина 				</b></td><td>	  washbasin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	розетка 				</b></td><td>	 socket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	сад 					</b></td><td>	 garden
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	светлый				</b></td><td>	 light
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	спальня 				</b></td><td>	 bedroom
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стена 					</b></td><td>	 wall
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стиральная машина			</b></td><td>	 washing machine
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стол 					</b></td><td>	 table
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	столовая 				</b></td><td>	 dining room
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	строить/построить			</b></td><td>	 to build
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стул 					</b></td><td>	 chair
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	телевизор 				</b></td><td>	 television set
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	телефон 				</b></td><td>	 telephone
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тёмный					</b></td><td>	 dark
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тряпка 					</b></td><td>	 rag
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	туалет 					</b></td><td>	 toilet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	туалетный столик			</b></td><td>	 dressing table
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	удобный				</b></td><td>	  convenient
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	утюг 					</b></td><td>	 iron
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	холодильник 				</b></td><td>	  fridge
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чистить/почистить зубы		</b></td><td>	 to clean teeth
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чистый					</b></td><td>	 clean
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шампунь 				</b></td><td>	 shampoo
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шкаф 					</b></td><td>	 cupboard
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	штора 					</b></td><td>	 blind
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	щётка 					</b></td><td>	 brush
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	этаж 					</b></td><td>	 floor
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ящик 					</b></td><td>	 drawer
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishTreeHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	акация	</b></td><td>	acacia 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	баобаб	</b></td><td>	baobab 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	берёза	</b></td><td>	birch 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бук	</b></td><td>	beech 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вяз	</b></td><td>	elm 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	грецкий орех	</b></td><td>	walnut 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	груша	</b></td><td>	pear tree 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дуб	</b></td><td>	oak 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ель	</b></td><td>	spruce 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ива	</b></td><td>	willow 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	инжир = смоковница = фига	</b></td><td>	fig 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	каштан	</b></td><td>	chestnut 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кедр	</b></td><td>	cedar 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кипарис	</b></td><td>	cypress 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клён	</b></td><td>	maple 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лавр	</b></td><td>	bay 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	липа	</b></td><td>	linden 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лиственница	</b></td><td>	larch 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	маслина = олива	</b></td><td>	olive 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мирт	</b></td><td>	myrtle 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	можжевельник	</b></td><td>	juniper </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ольха	</b></td><td>	alder 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	орешник	</b></td><td>	hazel 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	осина	</b></td><td>	aspen 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пальма	</b></td><td>	palm 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пихта	</b></td><td>	fir 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	платан	</b></td><td>	sycamore 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	рябина	</b></td><td>	mountain ash 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	секвойя	</b></td><td>	sequoia 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сирень	</b></td><td>	lilac 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	слива	</b></td><td>	plum tree 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сосна	</b></td><td>	pine 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тис	</b></td><td>	yew tree 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тополь	</b></td><td>	poplar 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	эвкалипт	</b></td><td>	eucalyptus 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	яблоня	</b></td><td>	apple tree 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ясень	</b></td><td>	ash 	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishGrammarHTML = @"
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	аббревиатура	</b></td><td>	abbreviation	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	абзац	</b></td><td>	paragraph	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	акроним	</b></td><td>	acronym	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	антоним	</b></td><td>	antonym	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	апостроф	</b></td><td>	apostrophe	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	артикль	</b></td><td>	article	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	будущее время	</b></td><td>	future tense	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	возвратное местоимение	</b></td><td>	reflexive pronoun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	вопросительный знак	</b></td><td>	question mark	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	восклицательный знак	</b></td><td>	exclamation mark 	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	время (грамматическое)	</b></td><td>	tense	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	вспомогательный глагол	</b></td><td>	auxiliary verb	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	герундий	</b></td><td>	gerund	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	главное предложение	</b></td><td>	main clause	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	глагол	</b></td><td>	verb	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	глагол-связка	</b></td><td>	linking verb	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	грамматический	</b></td><td>	grammatical	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	двоеточие	</b></td><td>	colon	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	действительный залог	</b></td><td>	active voice	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	дефис	</b></td><td>	hyphen	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	диалект	</b></td><td>	dialect	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	дополнение	</b></td><td>	object	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	единственное число	</b></td><td>	singular	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	запятая	</b></td><td>	comma	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	идиома	</b></td><td>	idiom	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	изменение формы слова	</b></td><td>	inflection	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	имя нарицательное	</b></td><td>	common noun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	имя собственное	</b></td><td>	proper noun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	инфинитив	</b></td><td>	infinitive	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кавычки	</b></td><td>	quotation mark	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	коммуникация	</b></td><td>	communication	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	круглая скобка </b></td><td>	parenthesis 	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	лингвист	</b></td><td>	linguist	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	лингвистика	</b></td><td>	linguistics	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	личное местоимение	</b></td><td>	personal pronoun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	междометие	</b></td><td>	interjection	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	местоимение	</b></td><td>	pronoun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	метафора	</b></td><td>	metaphor	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	множественное число	</b></td><td>	plural	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	морфология	</b></td><td>	morphology	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	написание	</b></td><td>	spelling	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	наречие	</b></td><td>	adverb	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	настоящее время	</b></td><td>	present tense	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	омоним	</b></td><td>	homonym	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	определение	</b></td><td>	qualifier 	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	падеж	</b></td><td>	case	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	палиндром	</b></td><td>	palindrome	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	подлежащее	</b></td><td>	subject	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	правило	</b></td><td>	rule	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	предикат	</b></td><td>	predicate	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	предлог	</b></td><td>	preposition	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	предложение	</b></td><td>	sentence	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	превосходная степень	</b></td><td>	superlative	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	придаточное дополнительное	</b></td><td>	objective clause	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	придаточное предложение	</b></td><td>	subordinate clause	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	прилагательное	</b></td><td>	adjective	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	причастие	</b></td><td>	participle	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	прописная буква	</b></td><td>	capital letter	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	прошедшее время	</b></td><td>	past tense	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	прямое дополнение	</b></td><td>	direct object	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	разговорный	</b></td><td>	colloquial	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	речь	</b></td><td>	speech	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	семантика	</b></td><td>	semantics	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	синоним	</b></td><td>	synonym	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	синтаксис	</b></td><td>	syntax	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	синтаксический	</b></td><td>	syntactic	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	склонение	</b></td><td>	declension	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сленг	</b></td><td>	slang	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	словарный запас	</b></td><td>	vocabulary	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	слово	</b></td><td>	word	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сложное предложение	</b></td><td>	compound sentence	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сложное слово	</b></td><td>	compound word	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сокращение	</b></td><td>	contraction	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	союз	</b></td><td>	conjunction	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	спряжение	</b></td><td>	conjugation	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сравнение	</b></td><td>	simile	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	страдательный залог	</b></td><td>	passive voice	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	существительное	</b></td><td>	noun	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	тире	</b></td><td>	dash	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	точка	</b></td><td>	period	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	точка с запятой	</b></td><td>	semicolon	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	фраза	</b></td><td>	phrase	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	эллипсис	</b></td><td>	ellipsis	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	язык	</b></td><td>	language	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishTownHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	аптека 							</b></td><td>	chemist's 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	арка 								</b></td><td>	arch
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	банк				 				</b></td><td>	bank
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бар 								</b></td><td>	bar
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бассейн 							</b></td><td>	swimming pool
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	библиотека 							</b></td><td>	library
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	больница 							</b></td><td>	hospital
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	булочная 							</b></td><td>	bakery
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	витрина 							</b></td><td>	window
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ворота 							</b></td><td>	gate
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	впечатляющий						</b></td><td>	impressive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	вход 								</b></td><td>	entrance
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	выбирать/выбрать						</b></td><td>	to choose
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	высококачественный					</b></td><td>	high-quality
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	выход 								</b></td><td>	exit
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	галерея 							</b></td><td>	gallery
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гастроном 							</b></td><td>	grocery 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гулять/погулять						</b></td><td>	to walk
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	движение 							</b></td><td>	traffic
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	делать/сделать покупки					</b></td><td>	to shop
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	денежный автомат						</b></td><td>	cash machine
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	деньги 							</b></td><td>	money
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дешёвый							</b></td><td>	cheap
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дорога 							</b></td><td>	road
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дорогой							</b></td><td>	expensive 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	дорожный знак						</b></td><td>	road sign
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	заблудиться							</b></td><td>	to get lost
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	затор 								</b></td><td>	traffic jam
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	здание 							</b></td><td>	building
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	зоопарк 							</b></td><td>	zoo
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	игрушечный магазин					</b></td><td>	toyshop
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	искать								</b></td><td>	to look for, search for, to seek
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	касса 								</b></td><td>	checkout
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кафе								</b></td><td>	cafe 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	квитанция (чек) 		 				</b></td><td>	receipt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кино								</b></td><td>	cinema
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	киоск 								</b></td><td>	stall
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	клумба 							</b></td><td>	Flower-bed
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	книжный магазин						</b></td><td>	bookshop
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кредитная карточка						</b></td><td>	credit card
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лифт 								</b></td><td>	lift
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	магазин 							</b></td><td>	shop
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мелочь 							</b></td><td>	change
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мечеть 							</b></td><td>	mosque
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	монета 							</b></td><td>	coin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мост 								</b></td><td>	bridge
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	музей 								</b></td><td>	museum
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мясной магазин						</b></td><td>	butcher's 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	находить/найти						</b></td><td>	to find
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	новый								</b></td><td>	new
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ночной клуб							</b></td><td>	nightclub
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	обувной магазин						</b></td><td>	shoe shop
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	памятник 							</b></td><td>	memorial, monument
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	парикмахерская 						</b></td><td>	hair salon
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	парк 								</b></td><td>	park
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	перекрёсток 							</b></td><td>	crossroads
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пешеход 							</b></td><td>	pedestrian
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	платить/заплатить (за что)					</b></td><td>	to pay 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	площадь 							</b></td><td>	square
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подарок 							</b></td><td>	present
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подержанный							</b></td><td>	second-hand
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подземный переход						</b></td><td>	underpass
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пожарное депо						</b></td><td>	fire station
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	покупатель 							</b></td><td>	buyer
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	покупать / купить						</b></td><td>	to buy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	получить							</b></td><td>	to receive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	почта 								</b></td><td>	post office
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	почтовый ящик						</b></td><td>	postbox, pillar box
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	прилавок			 				</b></td><td>	counter
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	примерочная 							</b></td><td>	fitting room
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	примерять							</b></td><td>	to try on
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	продавать							</b></td><td>	to sell
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	распродажа 							</b></td><td>	sale
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ресторан 							</b></td><td>	restaurant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рынок 								</b></td><td>	market
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	светофор 							</b></td><td>	traffic lights
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	синагога 							</b></td><td>	synagogue
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	скамья 							</b></td><td>	bench
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	скидка 							</b></td><td>	discount
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	собор 								</b></td><td>	cathedral
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стадион 							</b></td><td>	stadium
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	статуя 							</b></td><td>	statue
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стоить								</b></td><td>	to cost
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	стоянка такси						</b></td><td>	taxi-rank
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	театр 								</b></td><td>	theatre
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тротуар (мостовая)						</b></td><td>	pavement
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	угол								</b></td><td>	corner
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	узкий								</b></td><td>	narrow
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	улица 								</b></td><td>	street
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	универмаг 							</b></td><td>	department store
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	универсам 							</b></td><td>	supermarket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	уставать							</b></td><td>	to get tired
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	фонтан 							</b></td><td>	fountain
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	цена 								</b></td><td>	price
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	церковь 							</b></td><td>	church
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	цирк 								</b></td><td>	circus
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чек (банковский)						</b></td><td>	cheque
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чековая книжка						</b></td><td>	chequebook
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	широкий							</b></td><td>	wide
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	эскалатор 							</b></td><td>	escalator
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	этаж 								</b></td><td>	floor
</td></tr>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishAppearanceHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	arched 	</b></td><td>	 дугой
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	attractive 	</b></td><td>	 привлекательный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bald 	</b></td><td>	 лысый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	beard 	</b></td><td>	 борода
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	beautiful 	</b></td><td>	 красивый (о женщине или ребенке)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	beauty 	</b></td><td>	 красотка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	breast 	</b></td><td>	 грудь 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brows 	</b></td><td>	 брови
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bushy 	</b></td><td>	 густые
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	chin 	</b></td><td>	 подбородок
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	common 	</b></td><td>	 обычный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	complexion 	</b></td><td>	 цвет лица
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	dimples  	</b></td><td>	 ямочки (на щеках)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ear 	</b></td><td>	 ухо
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	elbow 	</b></td><td>	 локоть
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	face 	</b></td><td>	 лицо
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	fat 	</b></td><td>	 толстый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	figure 	</b></td><td>	 фигура
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	finger 	</b></td><td>	 палец (на руке)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	flush 	</b></td><td>	 румянец
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	foot 	</b></td><td>	 ступня
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	fresh 	</b></td><td>	 свежий
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	handsome	</b></td><td>	 красивый (о мужчине)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	hair-cut	</b></td><td>	 стрижка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	height 	</b></td><td>	 рост
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	knee 	</b></td><td>	 колено
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lashes 	</b></td><td>	 ресницы
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	leg 	</b></td><td>	 нога
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lobe 	</b></td><td>	 мочка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	curls 	</b></td><td>	 кудри
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	moustache 	</b></td><td>	 усы
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	mouth 	</b></td><td>	 рот
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	nail 	</b></td><td>	 ноготь
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	neck 	</b></td><td>	 шея
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	oval 	</b></td><td>	 овальный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pale 	</b></td><td>	 бледный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	palm  	</b></td><td>	 ладонь
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	penciled 	</b></td><td>	 нарисованные
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	plain 	</b></td><td>	 простой
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	plump 	</b></td><td>	 пухлый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	prominent ears 	</b></td><td>	 оттопыренные уши
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	round 	</b></td><td>	 круглый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	short 	</b></td><td>	 низкий
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	slim 	</b></td><td>	 тонкий
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	square 	</b></td><td>	 квадратный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	belly 	</b></td><td>	 живот
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	stooping 	</b></td><td>	 согнутый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	stout 	</b></td><td>	 полный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	straight 	</b></td><td>	 прямой
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	tall 	</b></td><td>	 высокий
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	thin 	</b></td><td>	 худой
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	thumb 	</b></td><td>	 большой палец (на руке)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to arrange 	</b></td><td>	 делать прическу
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to keep fit 	</b></td><td>	 держать форму
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	toe 	</b></td><td>	 палец (на ноге)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	tongue 	</b></td><td>	 язык
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ugly 	</b></td><td>	 уродливый
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	waist 	</b></td><td>	 талия
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	weight 	</b></td><td>	 вес
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	wrist 	</b></td><td>	 запястье
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishAnatomyHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	anatomy	</b></td><td>	анатомия	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	abdomen	</b></td><td>	живот	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	accouchement	</b></td><td>	роды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ankle	</b></td><td>	голеностоп	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	anus	</b></td><td>	проход задний	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	appendage	</b></td><td>	придаток	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	appendix	</b></td><td>	аппендикс	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	arm	</b></td><td>	рука	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	armpit	</b></td><td>	подмышка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	artery	</b></td><td>	артерия	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	backbone	</b></td><td>	позвоночник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	baldhead	</b></td><td>	лысина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	beard	</b></td><td>	борода	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	belch	</b></td><td>	отрыжка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	biceps	</b></td><td>	бицепс	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	birth	</b></td><td>	роды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blood	</b></td><td>	кровь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	body	</b></td><td>	тело	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bone	</b></td><td>	кость	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bowels	</b></td><td>	кишечник	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	brain	</b></td><td>	мозг	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	breast	</b></td><td>	грудь (женская)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	breath	</b></td><td>	дыхание	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	breech	</b></td><td>	ягодицы	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bronchus	</b></td><td>	бронх	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	build	</b></td><td>	телосложение	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	bust	</b></td><td>	бюст	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	calf	</b></td><td>	икра	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	canine	</b></td><td>	клык	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	capillary	</b></td><td>	капилляр	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cerebrum	</b></td><td>	мозг головной	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cheek	</b></td><td>	щека	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cheekbone	</b></td><td>	скула	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chin	</b></td><td>	подбородок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clavicle	</b></td><td>	ключица	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	corpse	</b></td><td>	труп	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	digestion	</b></td><td>	пищеварение	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dimple	</b></td><td>	ямка на щеке	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dream	</b></td><td>	сон	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ear	</b></td><td>	ухо	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	elbow	</b></td><td>	локоть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	enamel	</b></td><td>	зубная эмаль	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	entrails	</b></td><td>	кишки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyebrow	</b></td><td>	бровь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyelash	</b></td><td>	ресница	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyelid	</b></td><td>	веко	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	feaces	</b></td><td>	кал	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	finger	</b></td><td>	палец на руке	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	finiteness	</b></td><td>	конечность	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fist	</b></td><td>	кулак	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	flat-foot	</b></td><td>	плоскостопие	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	foot 	</b></td><td>	нога, ступня 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	footstep	</b></td><td>	стопа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	forearm	</b></td><td>	предплечье	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	forefinger	</b></td><td>	указательный палец	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	forehead	</b></td><td>	лоб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	freckle	</b></td><td>	веснушка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fringe	</b></td><td>	челка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	gland	</b></td><td>	лимфатический узел	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	groin	</b></td><td>	пах	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	gum	</b></td><td>	десна	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	haemoglobin	</b></td><td>	гемоглобин	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hair	</b></td><td>	волос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hand	</b></td><td>	кисть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	head	</b></td><td>	голова	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	health	</b></td><td>	здоровье	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	heart	</b></td><td>	сердце	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	heel	</b></td><td>	пятка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	hightemple	</b></td><td>	залысина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	immunity	</b></td><td>	иммунитет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	intestine	</b></td><td>	кишка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	jaw	</b></td><td>	челюсть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	kidney	</b></td><td>	почка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	knee	</b></td><td>	колено	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	larynx	</b></td><td>	гортань	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	leg	</b></td><td>	нога	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lip	</b></td><td>	губа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	liver	</b></td><td>	печень	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lung	</b></td><td>	легкое	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	melanism	</b></td><td>	родимое пятно	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	milk-tooth	</b></td><td>	молочный зуб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	molar	</b></td><td>	коренной зуб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	mole	</b></td><td>	родинка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	moustache	</b></td><td>	усы	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	mouth	</b></td><td>	рот	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	muscle	</b></td><td>	мышца	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	muscles	</b></td><td>	мускулатура	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nail	</b></td><td>	ноготь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nape	</b></td><td>	затылок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	navel	</b></td><td>	пупок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	neck	</b></td><td>	шея	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nerve	</b></td><td>	нерв	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nose	</b></td><td>	нос	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	nostril	</b></td><td>	ноздря	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	oesophagus	</b></td><td>	пищевод	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ovule	</b></td><td>	яйцеклетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	palm	</b></td><td>	ладонь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	papilla	</b></td><td>	сосок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pelvis	</b></td><td>	таз	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	puberty	</b></td><td>	половая зрелость	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pulse	</b></td><td>	пульс	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	pupil	</b></td><td>	зрачок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	rhesus	</b></td><td>	резус	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	rib	</b></td><td>	ребро	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	saliva	</b></td><td>	слюна	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	salivation	</b></td><td>	слюноотделение	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	scapula	</b></td><td>	лопатка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	sex	</b></td><td>	пол	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	shoulder	</b></td><td>	плечо	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	skeleton	</b></td><td>	скелет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	skin	</b></td><td>	кожа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	skull	</b></td><td>	череп	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	small fry	</b></td><td>	козявка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	snot	</b></td><td>	сопли	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	spine	</b></td><td>	позвоночный столб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stomach	</b></td><td>	желудок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stubble	</b></td><td>	щетина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	temple	</b></td><td>	висок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thigh	</b></td><td>	бедро	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thorax	</b></td><td>	грудная клетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	throat	</b></td><td>	горло	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thumb	</b></td><td>	большой палец руки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	toe	</b></td><td>	палец ноги	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tongue	</b></td><td>	язык	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tonsils	</b></td><td>	гланды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tooth 	</b></td><td>	зуб 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	urinarybladder	</b></td><td>	мочевой пузырь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	urine	</b></td><td>	моча	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vein	</b></td><td>	вена	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vertebra	</b></td><td>	позвонок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	wart	</b></td><td>	бородавка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	whisker	</b></td><td>	бакенбард	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishCulinaryHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	абрикос</b>    </td>    <td> apricot	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	баранина</b>    </td>    <td> lamb	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ананас</b>    </td>    <td>pineapple	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	анчоус</b>    </td>    <td>anchovy	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	апельсин</b>    </td>    <td>orange	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	арбуз</b>    </td>    <td>watermelon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	баклажан</b>    </td>    <td>aubergine	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	банан</b>    </td>    <td>banana	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	банка</b>    </td>    <td>jar, tin, can	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	белокочанная капуста</b>    </td>    <td>white cabbage	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бисквит</b>    </td>    <td>sponge (cake)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бифштекс</b>    </td>    <td>steak	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	блин</b>    </td>    <td>pancake	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	блюдо</b>    </td>    <td>dish, course </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	блюдце</b>    </td>    <td>saucer	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	брокколи</b>    </td>    <td>broccoli	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	булочка</b>    </td>    <td>roll	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бульон</b>    </td>    <td>bouillon</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бутерброд</b>    </td>    <td> sandwich	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	варенье</b>    </td>    <td>jam	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	варить/сварить</b>    </td>    <td>boil</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ветчина</b>    </td>    <td>ham	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вилка</b>    </td>    <td>fork	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вино</b>    </td>    <td>wine	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	виноград</b>    </td>    <td>grapes	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вкусный</b>    </td>    <td>nice, tasty	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	всыпать</b>    </td>    <td>pour in	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вяленый</b>    </td>    <td>dried	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гарнир</b>    </td>    <td>garnish </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	говядина</b>    </td>    <td>beef	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горох</b>    </td>    <td> peas	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горчица</b>    </td>    <td>mustard	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горький</b>    </td>    <td>bitter	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	горячий</b>    </td>    <td>hot	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	готовить</b>    </td>    <td>to cook	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	грейпфрут</b>    </td>    <td>grapefruit	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	грецкий орех</b>    </td>    <td>walnut	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гриб</b>    </td>    <td>mushroom	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	груша</b>    </td>    <td>pear	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	декор</b>    </td>    <td>decor	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	десерт</b>    </td>    <td>dessert	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дыня</b>    </td>    <td>melon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ежевика</b>    </td>    <td>blackberries	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	есть/съесть</b>    </td>    <td>to eat </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жарить/зажарить</b>    </td>    <td>to roast</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	желатин</b>    </td>    <td>gelatin(e)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	желе</b>    </td>    <td>jelly	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	желток</b>    </td>    <td>yolk	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жюльен</b>    </td>    <td>julienne	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	заварной</b>    </td>    <td>brewing	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	завтрак</b>    </td>    <td>breakfast	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	заказывать/заказать</b>    </td>    <td>to order</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	закуска</b>    </td>    <td>snack	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мясная закуска</b>    </td>    <td>collation	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	замешивать</b>    </td>    <td>mix; </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	замороженный</b>    </td>    <td>frozen	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	запечь</b>    </td>    <td>to bake	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	зелень (растительность)</b>    </td>    <td>greenery	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	изюм</b>    </td>    <td>raisins	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	имбирь</b>    </td>    <td>ginger	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	инжир (плод)</b>    </td>    <td>fig	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	йогурт</b>    </td>    <td>yoghurt	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кабачок</b>    </td>    <td>vegetable marrow	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	какао порошок</b>    </td>    <td>cocoa powder	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	капуста</b>    </td>    <td>cabbage	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	карамель</b>    </td>    <td>caramel	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	картофель</b>    </td>    <td>potatoes	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кастрюля</b>    </td>    <td>(sauce) pan	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	каштан (плод)</b>    </td>    <td>chestnut	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	киви</b>    </td>    <td>kiwi	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кислый</b>    </td>    <td>sour	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клубника</b>    </td>    <td>strawberries	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клюква</b>    </td>    <td>cranberries	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	колбаса</b>    </td>    <td> sausage	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	конфета</b>    </td>    <td> candy 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	коньяк</b>    </td>    <td>cognac	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	корень</b>    </td>    <td>root	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	корица</b>    </td>    <td>cinnamon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	котлета</b>    </td>    <td>rissole	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кофе</b>    </td>    <td>coffee	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	крахмал</b>    </td>    <td>starch	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	крепкий</b>    </td>    <td>strong	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кружка</b>    </td>    <td>mug	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кукуруза</b>    </td>    <td>maize	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кунжут</b>    </td>    <td>sesame	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	курага</b>    </td>    <td>dried apricots	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	курица</b>    </td>    <td>chicken	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лесной орех (фундук)</b>    </td>    <td>hazelnut	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ликёр</b>    </td>    <td>liqueur	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лимон</b>    </td>    <td>lemon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лимонад</b>    </td>    <td>lemonade	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ложка</b>    </td>    <td>spoon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лук (репчатый)</b>    </td>    <td>onions	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	лук-порей</b>    </td>    <td>leek	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	малина</b>    </td>    <td>raspberries	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мариновать</b>    </td>    <td>marinate, pickle	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	маслина</b>    </td>    <td>olive	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	масло</b>    </td>    <td>butter	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	олия</b>    </td>    <td> oil	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	маскарпони</b>    </td>    <td>mascarpone 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мёд</b>    </td>    <td>honey	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	меню</b>    </td>    <td>menu	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мидии</b>    </td>    <td>mussels	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	миндаль</b>    </td>    <td>almonds	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	миска</b>    </td>    <td> basin	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	молоко</b>    </td>    <td>milk	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	молотый</b>    </td>    <td>ground	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	морковь</b>    </td>    <td>carrots	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	моцарелла</b>    </td>    <td>mozzarella	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мука</b>    </td>    <td>flour;	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мусс</b>    </td>    <td>mousse	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мыть/вымыть посуду</b>    </td>    <td>to wash up </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мясо</b>    </td>    <td>meat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мята</b>    </td>    <td>mint	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	наливать/налить</b>    </td>    <td>to pour (out)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	напиток</b>    </td>    <td>drink, beverage	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	нож</b>    </td>    <td>knife	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	обед</b>    </td>    <td>dinner, lunch	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	обжарить</b>    </td>    <td>to fry </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	овощи</b>    </td>    <td>vegetables	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	огурец</b>    </td>    <td>cucumber	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	оливка</b>    </td>    <td>olive	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	орех</b>    </td>    <td>nut	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	острый</b>    </td>    <td>spicy	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	отбить</b>    </td>    <td>to beat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	отварной</b>    </td>    <td>boiled	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	паприка</b>    </td>    <td>paprika	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пахнуть</b>    </td>    <td>to smell 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	паштет</b>    </td>    <td>pate	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	перемешивать (размешивать)</b>    </td>    <td>stir	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	перец</b>    </td>    <td>pepper	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	персик</b>    </td>    <td>peach	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	петрушка</b>    </td>    <td>parsley	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	печь/испечь</b>    </td>    <td>to bake	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пиво</b>    </td>    <td>beer	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пирог</b>    </td>    <td>pie	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пить/выпить</b>    </td>    <td>to drink	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пища</b>    </td>    <td>food </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пластина</b>    </td>    <td>slice	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	подача</b>    </td>    <td>serving	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	помидор</b>    </td>    <td>tomato	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	приправа</b>    </td>    <td> relish	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пропаривать</b>    </td>    <td>to steam 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пшеница</b>    </td>    <td>wheat	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пшеничная мука</b>    </td>    <td>wheat flour	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пюре</b>    </td>    <td>puree;	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ржаной</b>    </td>    <td>rye	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	рис</b>    </td>    <td>rice	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	рулет</b>    </td>    <td> roll</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	рыба</b>    </td>    <td>fish	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	салат</b>    </td>    <td>lettuce, salad	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сахар</b>    </td>    <td>sugar	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	свежий</b>    </td>    <td>fresh	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	свёкла</b>    </td>    <td>beetroot	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	свинина</b>    </td>    <td>pork	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сельдерей</b>    </td>    <td>celery	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	семга</b>    </td>    <td>salmon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сидр</b>    </td>    <td>cider	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сироп</b>    </td>    <td>syrup	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сковородка</b>    </td>    <td>frying pan	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	слабый</b>    </td>    <td>weak	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сладкий</b>    </td>    <td>sweet	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	слива</b>    </td>    <td>plum	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сливки</b>    </td>    <td>cream	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сливочный крем</b>    </td>    <td>buttercream 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	смазать</b>    </td>    <td>to smear (with)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	смесь (результат смешивания)</b>    </td>    <td>mixture	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сметана</b>    </td>    <td>sour cream	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	смородина</b>    </td>    <td>currants	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сок</b>    </td>    <td>juice	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	солёный</b>    </td>    <td>salty	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	соль</b>    </td>    <td>salt	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сорбет (сорбе)</b>    </td>    <td>sorbet	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	соус</b>    </td>    <td>sauce	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	соя</b>    </td>    <td>soya	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	специи</b>    </td>    <td>spicery	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	стакан</b>    </td>    <td>glass	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	стерлядь</b>    </td>    <td>sterlet	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	судак</b>    </td>    <td>zander</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	суп</b>    </td>    <td>soup	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	суфле</b>    </td>    <td>souffle	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	счёт</b>    </td>    <td>bill	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сыр</b>    </td>    <td>cheese	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сырой</b>    </td>    <td>raw	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тарелка</b>    </td>    <td>plate	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	творог</b>    </td>    <td>curds	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	телятина</b>    </td>    <td>veal	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тесто</b>    </td>    <td> dough</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	толчёный</b>    </td>    <td>pounded	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	торт</b>    </td>    <td>cake	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ужин</b>    </td>    <td>dinner, supper	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	уксус</b>    </td>    <td>vinegar	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	форель</b>    </td>    <td>trout	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фарш</b>    </td>    <td>stuffing</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фасоль</b>    </td>    <td> beans </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фенхель</b>    </td>    <td>fennel	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	филе</b>    </td>    <td>fillet</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	фрукт</b>    </td>    <td> fruit	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	хлеб</b>    </td>    <td>bread	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	хотеть есть</b>    </td>    <td>to be hungry </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	хотеть пить</b>    </td>    <td>to be thirsty	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	цедра</b>    </td>    <td>rind	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чай</b>    </td>    <td>tea	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чашка</b>    </td>    <td>cup	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	черешня</b>    </td>    <td>cherry	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чёрная смородина</b>    </td>    <td>blackcurrants	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чеснок</b>    </td>    <td>garlic	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чечевица</b>    </td>    <td>lentil	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	чистить</b>    </td>    <td>to peel</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	шампиньон</b>    </td>    <td>champignon	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	шафран</b>    </td>    <td>saffron	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	шпинат</b>    </td>    <td>spinach	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	эссенция</b>    </td>    <td>essence	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	яблоко</b>    </td>    <td>apple </td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	яйцо</b>    </td>    <td>egg	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
