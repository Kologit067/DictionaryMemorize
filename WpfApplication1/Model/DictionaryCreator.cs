using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DictionaryLibrary.Model;

namespace DictionaryMemorize.Model
{
    public partial class DictionaryCreator
    {

        //-------------------------------------------------------------------------------------------------------------------
        public static List<Word> CreatePronouns(Dictionary<string, List<Word>>  WordDictionary)
        {
            List<Word> lWords = new System.Collections.Generic.List<Word>() {
            new Word(){Native = "I", Translation = "я"},
            new Word(){Native = "you", Translation = "ты"},
            new Word(){Native = "he", Translation = "он"},
            new Word(){Native = "she", Translation = "она"},
            new Word(){Native = "it", Translation = "оно"},
            new Word(){Native = "we", Translation = "мы"},
            new Word(){Native = "they", Translation = "они"},
            new Word(){Native = "me", Translation = "мне"},
            new Word(){Native = "him", Translation = "ему"},
            new Word(){Native = "her", Translation = "ей"},
            new Word(){Native = "his", Translation = "его"},
            new Word(){Native = "my", Translation = "мой"},
            new Word(){Native = "our", Translation = "наш"},
            new Word(){Native = "your", Translation = "твой"},
            new Word(){Native = "their", Translation = "их"}
            };
            if (WordDictionary.ContainsKey("Pronouns"))
                WordDictionary["Pronouns"] = lWords;
            else
                WordDictionary.Add("Pronouns", lWords);
            return lWords;
        }
        //-------------------------------------------------------------------------------------------------------------------
        /*
        static public List<Word> CreateFromHTML()
        {
            List<Word> lWords = new List<Word>();
            string pattern = @"<tr>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*</tr>";
            //            Match match = Regex.Match(stringHTML, pattern);
            foreach (Match match in Regex.Matches(stringHTML, pattern))
            {

                Word v = new Word() { Native = match.Groups[1].Value, Translation = match.Groups[2].Value };
                lWords.Add(v);
                if (lWords.Count > 9)
                    break;
            }
            return lWords;
        }
         * */
         //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateAnimalFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Animal", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringAnimalHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateFoodFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Food", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringFoodHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateFruitsFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Fruits", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringFruitsHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateTransportFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Transport", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringTransportHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateNumbersFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Numbers", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringNumbersHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateColorsFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Colors", @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>", stringColorsHTML);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateQuestionsFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Questions", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\?\s+</b></td>\s*<td>\s+([^<>]+)\?\s+</td>\s*</tr>", stringQuestionsHTML, 2, 3);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateAnatomyFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Anatomy", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\s+</b></td>\s*<td>\s+([^<>]+)\s+</td>\s*</tr>", stringAnatomyHTML, 2, 3);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateWeekDaysFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "WeekDays", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\s+</td>\s*<td([^<>]+)>\s+<b>([^<>]+)\s+</b><br></td>\s*</tr>", stringWeekDaysHTML, 4, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateDayFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Day", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\s+</b></td>\s*<td([^<>]+)>\s+([^<>]+)\s+</td>\s*</tr>", stringDayHTML, 4, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateMonthFromHTML(Dictionary<string, List<Word>>  WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Month", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\s+</td>\s*<td([^<>]+)>\s+<b>([^<>]+)</b>\s+</td>\s*</tr>", stringMonthHTML, 4, 2);
            //return CreateDictFromTextByRegex("Month", @"<tr>\s*<td([^<>]+)><b>\s+([^<>]+)\s+</td>\s*<td([^<>]+)>\s+<b>([^<>]+)</b>\s+</td>", stringMonthHTML, 2, 3);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateDictFromTextByRegex(Dictionary<string, List<Word>>  WordDictionary,
            string pDictionaryName, string pPattern, string pStringHTML, int pNativeIdex = 1, int pTranslationIndex = 3)
        {

            try
            {
                List<Word> lWords = new List<Word>();
                if (WordDictionary.ContainsKey(pDictionaryName))
                    lWords = WordDictionary[pDictionaryName];
                lWords.Clear();
                foreach (Match match in Regex.Matches(pStringHTML, pPattern))
                {

                    Word v = new Word() { Native = match.Groups[pNativeIdex].Value.Trim(), Translation = match.Groups[pTranslationIndex].Value.Trim() };
                    if (!lWords.Any(c => c.Native == v.Native))
                        lWords.Add(v);
                }
                if (WordDictionary.ContainsKey(pDictionaryName))
                    WordDictionary[pDictionaryName] = lWords;
                else
                    WordDictionary.Add(pDictionaryName, lWords);
                return lWords;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                throw;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringMonthHTML = @" 
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	январь	</td>    <td height=""24"" >	<b>January</b>     </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	февраль	</td>    <td height=""24"" >	<b>February</b>    </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	март	</td>    <td height=""24"" >	<b>March</b>    </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	апрель	</td>    <td height=""24"" >	<b>April </b>   </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	май	</td>    <td height=""24"" >	<b>May </b>    	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	июнь	</td>    <td height=""24"" >	<b>June </b>    </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	июль	</td>    <td height=""24"" >	<b>July</b>     </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	август	</td>    <td height=""24"" >	<b>August</b>   </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	сентябрь	</td>    <td height=""24"" >	<b>September</b> </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	октябрь	</td>    <td height=""24"" >	<b>October</b>     </td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	ноябрь	</td>    <td height=""24"" >	<b>November</b>    	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	декабрь	</td>    <td height=""24"" >	<b>December</b>    	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringDayHTML = @"
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	будни	</b></td><td height=""24"" >	weekdays	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	вечер	</b></td><td height=""24"" >	evening	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	восход	</b></td><td height=""24"" >	sunrise	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	вчера	</b></td><td height=""24"" >	yesterday	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	день	</b></td><td height=""24"" > day</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	день_рождения	</b></td><td height=""24"" >	birthday	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	завтра	</b></td><td height=""24"" >	tomorrow	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	закат	</b></td><td height=""24"" >	sunset	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	неделя	</b></td><td height=""24"" >	week	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	ночь	</b></td><td height=""24"" >	night	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	полдень	</b></td><td height=""24"" >	noon	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	полночь	</b></td><td height=""24"" >	midnight	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	праздник	</b></td><td height=""24"" >	holiday	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	рассвет	</b></td><td height=""24"" >	daybreak	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	сегодня	</b></td><td height=""24"" >	today	</td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	утро	</b></td><td height=""24"" >	morning	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringWeekDaysHTML = @"
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	понедельник	   </td>    <td height=""24"" >	<b>Monday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	вторник	    </td>    <td height=""24"" >	<b>Tuesday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	среда	   </td>    <td height=""24"" >	<b>Wednesday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	четверг	   </td>    <td height=""24"" >	<b>Thursday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	пятница	   </td>    <td height=""24"" >	<b>Friday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	суббота	    </td>    <td height=""24"" >	<b>Saturday </b><br></td></tr>
<tr><td height=""24""  bgcolor=""#FFFFDD""><b>	воскресенье	   </td>    <td height=""24"" >	<b>Sunday </b><br></td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringAnatomyHTML = @"
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
<tr><td bgcolor=""#FFFFDD""><b>	bald head	</b></td><td>	лысина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	beard	</b></td><td>	борода	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	belch	</b></td><td>	отрыжка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	biceps	</b></td><td>	бицепс	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	birth	</b></td><td>	роды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blood	</b></td><td>	кровь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	blood vessel	</b></td><td>	сосуд_кровеносный	</td></tr>
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
<tr><td bgcolor=""#FFFFDD""><b>	cerebrum	</b></td><td>	мозг_головной	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cheek	</b></td><td>	щека	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	cheekbone	</b></td><td>	скула	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	chin	</b></td><td>	подбородок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	clavicle	</b></td><td>	ключица	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	corpse	</b></td><td>	труп	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	digestion	</b></td><td>	пищеварение	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dimple	</b></td><td>	ямка_на_щеке	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	dream	</b></td><td>	сон	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ear	</b></td><td>	ухо	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	elbow	</b></td><td>	локоть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	entrails	</b></td><td>	кишки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyebrow	</b></td><td>	бровь	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyelash	</b></td><td>	ресница	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	eyelid	</b></td><td>	веко	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	feaces	</b></td><td>	кал	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	finger	</b></td><td>	палец_на_руке	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	finiteness	</b></td><td>	конечность	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	fist	</b></td><td>	кулак	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	flat-foot	</b></td><td>	плоскостопие	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	foot	</b></td><td>	ступня	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	footstep	</b></td><td>	стопа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	forearm	</b></td><td>	предплечье	</td></tr>
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
<tr><td bgcolor=""#FFFFDD""><b>	high temple	</b></td><td>	залысина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	immunity	</b></td><td>	иммунитет	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	intestine	</b></td><td>	кишка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	jaw	</b></td><td>	челюсть	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	kidney	</b></td><td>	почка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	knee	</b></td><td>	колено	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	larynx	</b></td><td>	гортань	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	leg	</b></td><td>	нога	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lip	</b></td><td>	губа	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	liver	</b></td><td>	печень	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	little toe	</b></td><td>	мизинец ноги	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	little finger	</b></td><td>	мизинец руки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	lung	</b></td><td>	легкое	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	melanism	</b></td><td>	родимое_пятно	</td></tr>
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
<tr><td bgcolor=""#FFFFDD""><b>	puberty	</b></td><td>	половая_зрелость	</td></tr>
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
<tr><td bgcolor=""#FFFFDD""><b>	snot	</b></td><td>	сопли	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	spine	</b></td><td>	позвоночный_столб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stomach	</b></td><td>	желудок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	stubble	</b></td><td>	щетина	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	temple	</b></td><td>	висок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thigh	</b></td><td>	бедро	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thorax	</b></td><td>	грудная клетка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	throat	</b></td><td>	горло	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	thumb	</b></td><td>	большой_палец_руки	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	toe	</b></td><td>	палец_ноги	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tongue	</b></td><td>	язык	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tonsils	</b></td><td>	гланды	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	tooth	</b></td><td>	зуб	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	urine	</b></td><td>	моча	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vein	</b></td><td>	вена	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	vertebra	</b></td><td>	позвонок	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	wart	</b></td><td>	бородавка	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	whisker	</b></td><td>	бакенбард	</td></tr>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringQuestionsHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	Who?	</b></td><td>	   Кто?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	What?	</b></td><td>	   Что?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	Which?	</b></td><td>	     Какой?        Который?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	When?	</b></td><td>	     Когда?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	Where?	</b></td><td>	   Где?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	Why?	</b></td><td>	      Почему?	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	How?	</b></td><td>	   Как?	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringColorsHTML = @"
<p>&nbsp;&nbsp; 1. Red &ndash; красный</p>
<p>&nbsp;&nbsp; 2. Orange &ndash; оранжевый</p>
<p>&nbsp;&nbsp; 3. Yellow &ndash; желтый</p>
<p>&nbsp;&nbsp; 4. Green &ndash; зеленый</p>
<p>&nbsp;&nbsp; 5. Blue &ndash; голубой</p>
<p>&nbsp;&nbsp; 6. Purple &ndash; фиолетовый</p>
<p>&nbsp;&nbsp; 7. Pink &ndash; розовый</p>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringNumbersHTML = @"
<p>&nbsp;&nbsp; 1. One - один</p>
<p>&nbsp;&nbsp; 2. Two - два</p>
<p>&nbsp;&nbsp; 3. Three &ndash; три</p>
<p>&nbsp;&nbsp; 4. Four &ndash; четыре</p>
<p>&nbsp;&nbsp; 5. Five &ndash; пять</p>
<p>&nbsp;&nbsp; 6. Six &ndash; шесть</p>
<p>&nbsp;&nbsp; 7. Seven &ndash; семь</p>
<p>&nbsp;&nbsp; 8. Eight &ndash; восемь</p>
<p>&nbsp;&nbsp; 9. Nine - девять</p>
<p>&nbsp;&nbsp; 10. Ten &ndash; десять</p>
<p>&nbsp;&nbsp; 11. Eleven &ndash; одиннадцать</p>
<p>&nbsp;&nbsp; 12. Twelve &ndash; двенадцать</p>
<p>&nbsp;&nbsp; 13. Thirteen &ndash; тринадцать</p>
<p>&nbsp;&nbsp; 14. Fourteen &ndash; четырнадцать</p>
<p>&nbsp;&nbsp; 15. Fifteen &ndash; пятнадцать</p>
<p>&nbsp;&nbsp; 16. Sixteen &ndash; шестнадцать</p>
<p>&nbsp;&nbsp; 17. Seventeen &ndash; семнадцать</p>
<p>&nbsp;&nbsp; 18. Eighteen &ndash; восемнадцать</p>
<p>&nbsp;&nbsp; 19. Nineteen &ndash; девятнадцать</p>
<p>&nbsp;&nbsp; 20. Twenty &ndash; двадцать</p>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringTransportHTML = @"
<p>&nbsp;&nbsp; 1. car &ndash; машина</p>
<p>&nbsp;&nbsp; 2. bus &ndash; автобус</p>
<p>&nbsp;&nbsp; 3. train &ndash; поезд</p>
<p>&nbsp;&nbsp; 4. bike &ndash; велосипед</p>
<p>&nbsp;&nbsp; 5. ship &ndash; корабль</p>
<p>&nbsp;&nbsp; 6. tram &ndash; трамвай</p>
<p>&nbsp;&nbsp; 7. trolley-bus &ndash; троллейбус</p>
<p>&nbsp;&nbsp; 8. helicopter &ndash; вертолет</p>
<p>&nbsp;&nbsp; 9. rocket &ndash; ракета</p>
<p>&nbsp;&nbsp; 10. plane &ndash; самолет</p>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringFruitsHTML = @"
<p>&nbsp;&nbsp; 1. pineapple &ndash; ананас</p>
<p>&nbsp;&nbsp; 2. Grapes &ndash; виноград</p>
<p>&nbsp;&nbsp; 3. Blueberries &ndash; черника</p>
<p>&nbsp;&nbsp; 4. strawberry &ndash; клубника</p>
<p>&nbsp;&nbsp; 5. kiwi &ndash; киви</p>
<p>&nbsp;&nbsp; 6. pear &ndash; груша</p>
<p>&nbsp;&nbsp; 7. orange &ndash; апельсин</p>
<p>&nbsp;&nbsp; 8. lemon &ndash; лимон</p>
<p>&nbsp;&nbsp; 9. apple &ndash; яблоко</p>
<p>&nbsp;&nbsp; 10. watermelon &ndash; арбуз</p>
<p>&nbsp;&nbsp; 11. Cherries - вишни</p>
<p>&nbsp;&nbsp; 12. grapefruit &ndash; грейпфрут</p>
<p>&nbsp;&nbsp; 13. plum &ndash; слива</p>
<p>&nbsp;&nbsp; 14. Bananas &ndash; бананы</p>
<p>&nbsp;&nbsp; 15. peach &ndash; персик</p>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringFoodHTML = @"
<<p>&nbsp;&nbsp; 1. Pizza &ndash; пицца</p>
<p>&nbsp;&nbsp; 2. Soup &ndash; суп</p>
<p>&nbsp;&nbsp; 3. Cake &ndash; пирог</p>
<p>&nbsp;&nbsp; 4. Sandwich &ndash; бутерброд</p>
<p>&nbsp;&nbsp; 5. Chocolate &ndash; шоколад</p>
<p>&nbsp;&nbsp; 6. Potato &ndash; картошка</p>
<p>&nbsp;&nbsp; 8. Egg &ndash; яйцо</p>
<p>&nbsp;&nbsp; 9. Macaroni&ndash; макароны</p>
<p>&nbsp;&nbsp; 10. Sausage &ndash; колбаса</p>
<p>&nbsp;&nbsp; 11. Tea &ndash; чай</p>
<p>&nbsp;&nbsp; 12. Salt - соль</p>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringAnimalHTML = @"
<p>&nbsp;&nbsp; 2. Snake &ndash; змея</p>
<p>&nbsp;&nbsp; 3. Camel &ndash; верблюд</p>
<p>&nbsp;&nbsp; 4. Hedgehog &ndash; еж</p>
<p>&nbsp;&nbsp; 5. Bat &ndash; кажан</p>
<p>&nbsp;&nbsp; 6. Zebra &ndash; зебра</p>
<p>&nbsp;&nbsp; 7. Crocodile &ndash; крокодил</p>
<p>&nbsp;&nbsp; 8. Bird &ndash; птица</p>
<p>&nbsp;&nbsp; 9. Seal &ndash; тюлень</p>
<p>&nbsp;&nbsp; 10. Elephant - слон</p>
<p>&nbsp;&nbsp; 11. Bear &ndash; медведь</p>
<p>&nbsp;&nbsp; 12. Turtle &ndash; черепаха</p>
<p>&nbsp;&nbsp; 13. Squirrel &ndash; белка</p>
<p>&nbsp;&nbsp; 14. Cow &ndash; корова</p>
<p>&nbsp;&nbsp; 15. Sheep &ndash; овца</p>
<p>&nbsp;&nbsp; 16. Pig &ndash; свинья</p>
<p>&nbsp;&nbsp; 17. Horse &ndash; лошадь</p>
<p>&nbsp;&nbsp; 18. Duck &ndash; утка</p>
<p>&nbsp;&nbsp; 19. Cat &ndash; кот</p>
<p>&nbsp;&nbsp; 20. Dog &ndash; собака</p>
<p>&nbsp;&nbsp; 21. Owl - сова</p>
<p>&nbsp;&nbsp; 22. Hippo &ndash; гиппопотам</p>
<p>&nbsp;&nbsp; 23. Parrot &ndash; попугай</p>";
    }
}
