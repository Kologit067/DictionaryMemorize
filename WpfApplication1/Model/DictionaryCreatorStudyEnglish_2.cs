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
        static public List<Word> CreateStudyEnglishArtFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Art",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishArtHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishCareerFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Career",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishCareerHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishBushesFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Bushes",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishBushesHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishComputerFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Computer",
@"<tr><td\s+bgcolor[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishComputerHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishFurnitureFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Furniture",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishFurnitureHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishInsectsFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Insects",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishInsectsHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishMusicFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Music",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishMusicHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishClothingFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Clothing",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishClothingHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishProfessionsFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Professions",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishProfessionsHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishCharacterFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Character",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>\s*</td>\s*<td>\s*([^>]+)\s*</td></tr>", stringStudyEnglishCharacterHTML, 2, 1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateStudyEnglishColorFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "StudyEnglish-Color",
@"<tr><td\s+[^>]+><b>\s*([^>]+)\s*</b>[^<]*</td>\s*<td[^>]*>\s*([^>]+)\s*</td>\s*</tr>", stringStudyEnglishColorHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishColorHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>amber</b></td><td  bgcolor=""#ffffff"">янтарный</td></tr>
<tr><td bgcolor=""#FFFFDD""><b> 
anise </b></td><td  bgcolor=""#ffffff"">
анис</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
apricot</b></td><td  bgcolor=""#ffffff"">
абрикосовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
aqua</b></td><td  bgcolor=""#ffffff"">
морская волна</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
aquamarine</b></td><td  bgcolor=""#ffffff"">
аквамарин</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
ash</b></td><td  bgcolor=""#ffffff"">
пепельно-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
azure</b></td><td  bgcolor=""#ffffff"">
лазурный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
beige</b></td><td  bgcolor=""#ffffff"">
бежевый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
berry</b></td><td  bgcolor=""#ffffff"">
ягодный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
black</b></td><td  bgcolor=""#ffffff"">
черный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
blue</b></td><td  bgcolor=""#ffffff"">
синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
blue violet</b></td><td  bgcolor=""#ffffff"">
фиолетово-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
bottle green</b></td><td  bgcolor=""#ffffff"">
бутылочный зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
bronze</b></td><td  bgcolor=""#ffffff"">
бронзовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
brown</b></td><td  bgcolor=""#ffffff"">
коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
buff</b></td><td  bgcolor=""#ffffff"">
светло-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
burgundy</b></td><td  bgcolor=""#ffffff"">
бордовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
burgundy</b></td><td  bgcolor=""#ffffff"">
красный (бургундское вино)</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
burly wood</b></td><td  bgcolor=""#ffffff"">
желтоватый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
burnt</b></td><td  bgcolor=""#ffffff"">
жженый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
buttercup yellow</b></td><td  bgcolor=""#ffffff"">
светло-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cadet blue</b></td><td  bgcolor=""#ffffff"">
серо-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cambridge blue</b></td><td  bgcolor=""#ffffff"">
светло-голубой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
camel</b></td><td  bgcolor=""#ffffff"">
верблюжий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cerise</b></td><td  bgcolor=""#ffffff"">
светло-вишневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
charcoal</b></td><td  bgcolor=""#ffffff"">
древесный уголь</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
chartreuse</b></td><td  bgcolor=""#ffffff"">
бледно-зелёный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
chartreuse</b></td><td  bgcolor=""#ffffff"">
зеленовато-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
chlorine</b></td><td  bgcolor=""#ffffff"">
светло-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
chocolate</b></td><td  bgcolor=""#ffffff"">
шоколадный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
claret</b></td><td  bgcolor=""#ffffff"">
бордо</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
clay</b></td><td  bgcolor=""#ffffff"">
глиняный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
clay-colored</b></td><td  bgcolor=""#ffffff"">
светло-бурый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cocoa</b></td><td  bgcolor=""#ffffff"">
цвет какао</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
copper</b></td><td  bgcolor=""#ffffff"">
медный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
coral</b></td><td  bgcolor=""#ffffff"">
коралловый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cornflower</b></td><td  bgcolor=""#ffffff"">
васильковый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cornsilk</b></td><td  bgcolor=""#ffffff"">
шелковый оттенок</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cream</b></td><td  bgcolor=""#ffffff"">
кремовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cream</b></td><td  bgcolor=""#ffffff"">
сливочный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
cyan</b></td><td  bgcolor=""#ffffff"">
зеленовато-голубой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark blue</b></td><td  bgcolor=""#ffffff"">
темно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark cyan</b></td><td  bgcolor=""#ffffff"">
темный циан</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark gray</b></td><td  bgcolor=""#ffffff"">
темно-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark green</b></td><td  bgcolor=""#ffffff"">
темно-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark magenta</b></td><td  bgcolor=""#ffffff"">
фуксин темный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark red</b></td><td  bgcolor=""#ffffff"">
темно-красный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dark yellow</b></td><td  bgcolor=""#ffffff"">
темно-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
deep blue</b></td><td  bgcolor=""#ffffff"">
глубокий синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
deep-brown</b></td><td  bgcolor=""#ffffff"">
темно-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
deep-green</b></td><td  bgcolor=""#ffffff"">
темно-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
denim blue</b></td><td  bgcolor=""#ffffff"">
джинсовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dim gray</b></td><td  bgcolor=""#ffffff"">
тускло-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dull</b></td><td  bgcolor=""#ffffff"">
тусклый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
dusty</b></td><td  bgcolor=""#ffffff"">
пыльный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
ecru</b></td><td  bgcolor=""#ffffff"">
цвет небелёного сурового полотна</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
emerald</b></td><td  bgcolor=""#ffffff"">
изумрудный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
fallow</b></td><td  bgcolor=""#ffffff"">
светло-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
firebrick</b></td><td  bgcolor=""#ffffff"">
кирпичный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
forest</b></td><td  bgcolor=""#ffffff"">
лесной</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
forest green</b></td><td  bgcolor=""#ffffff"">
зеленый лесной</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
forest green</b></td><td  bgcolor=""#ffffff"">
хаки</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
fuchsia</b></td><td  bgcolor=""#ffffff"">
фуксия</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
garnet</b></td><td  bgcolor=""#ffffff"">
темно-красный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
ghostwhite</b></td><td  bgcolor=""#ffffff"">
призрачно-белый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
ginger brown</b></td><td  bgcolor=""#ffffff"">
рыжевато-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
gold</b></td><td  bgcolor=""#ffffff"">
золотой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
golden</b></td><td  bgcolor=""#ffffff"">
золотой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
goldenrod</b></td><td  bgcolor=""#ffffff"">
золотистый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
gray</b></td><td  bgcolor=""#ffffff"">
серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
green</b></td><td  bgcolor=""#ffffff"">
зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
green yellow</b></td><td  bgcolor=""#ffffff"">
зелено-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
grey; gray</b></td><td  bgcolor=""#ffffff"">
серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
honeydew</b></td><td  bgcolor=""#ffffff"">
медовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
hot pink</b></td><td  bgcolor=""#ffffff"">
теплый розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
hunter green</b></td><td  bgcolor=""#ffffff"">
зелёный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
indigo</b></td><td  bgcolor=""#ffffff"">
индиго</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
ivory</b></td><td  bgcolor=""#ffffff"">
слоновая кость</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
jade</b></td><td  bgcolor=""#ffffff"">
желтовато-зелёный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
khaki</b></td><td  bgcolor=""#ffffff"">
хаки</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lavender</b></td><td  bgcolor=""#ffffff"">
бледно-лиловый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lavender</b></td><td  bgcolor=""#ffffff"">
лаванда</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lavender blush</b></td><td  bgcolor=""#ffffff"">
голубой с красным отливом</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lawn green</b></td><td  bgcolor=""#ffffff"">
зеленая лужайка</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lemon</b></td><td  bgcolor=""#ffffff"">
лимонный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lemon chiffon</b></td><td  bgcolor=""#ffffff"">
лимонный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light blue</b></td><td  bgcolor=""#ffffff"">
светло-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light coral</b></td><td  bgcolor=""#ffffff"">
коралловый светлый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light cyan</b></td><td  bgcolor=""#ffffff"">
светлый циан</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light goldenrod</b></td><td  bgcolor=""#ffffff"">
светло-золотистый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light goldenrod yellow</b></td><td  bgcolor=""#ffffff"">
светло-желтый золотистый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light gray</b></td><td  bgcolor=""#ffffff"">
светло-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light pink</b></td><td  bgcolor=""#ffffff"">
светло-розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light salmon</b></td><td  bgcolor=""#ffffff"">
светлый сомон</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light seagreen</b></td><td  bgcolor=""#ffffff"">
цвет морской волны, светлый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light sky blue</b></td><td  bgcolor=""#ffffff"">
небесно-голубой светлый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light slate blue</b></td><td  bgcolor=""#ffffff"">
светлый грифельно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light slate gray</b></td><td  bgcolor=""#ffffff"">
грифельно-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light steel blue</b></td><td  bgcolor=""#ffffff"">
голубой со стальным оттенком</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light yellow</b></td><td  bgcolor=""#ffffff"">
светло-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
light-green</b></td><td  bgcolor=""#ffffff"">
салатовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lilac</b></td><td  bgcolor=""#ffffff"">
сиреневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lime</b></td><td  bgcolor=""#ffffff"">
цвет лайма</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
lime green</b></td><td  bgcolor=""#ffffff"">
лимонно-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
liver-coloured</b></td><td  bgcolor=""#ffffff"">
темно-каштановый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
livery</b></td><td  bgcolor=""#ffffff"">
темно-каштановый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
magenta</b></td><td  bgcolor=""#ffffff"">
пурпурный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
magenta</b></td><td  bgcolor=""#ffffff"">
фуксин</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
maroon</b></td><td  bgcolor=""#ffffff"">
темно-бордовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mastic</b></td><td  bgcolor=""#ffffff"">
бледно-желтый, цвет мастики</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mauve</b></td><td  bgcolor=""#ffffff"">
розовато-лиловый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mazarine</b></td><td  bgcolor=""#ffffff"">
темно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
medium gray</b></td><td  bgcolor=""#ffffff"">
серый нейтральный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
medium green</b></td><td  bgcolor=""#ffffff"">
средне-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
midnight blue</b></td><td  bgcolor=""#ffffff"">
полуночно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mint</b></td><td  bgcolor=""#ffffff"">
мятный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
misty rose</b></td><td  bgcolor=""#ffffff"">
тускло-розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mole</b></td><td  bgcolor=""#ffffff"">
серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
mouse grey</b></td><td  bgcolor=""#ffffff"">
мышиный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
murrey</b></td><td  bgcolor=""#ffffff"">
темно-красный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
navajo white</b></td><td  bgcolor=""#ffffff"">
белый-навахо</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
navy</b></td><td  bgcolor=""#ffffff"">
темно-синий цвет (цвет формы морских
офицеров)</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
navy blue</b></td><td  bgcolor=""#ffffff"">
тёмно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
navy, dark blue</b></td><td  bgcolor=""#ffffff"">
темно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
nutmeg</b></td><td  bgcolor=""#ffffff"">
цет мускатного ореха</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
off-white</b></td><td  bgcolor=""#ffffff"">
грязно-белый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
olive</b></td><td  bgcolor=""#ffffff"">
оливковый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
olive green</b></td><td  bgcolor=""#ffffff"">
оливковый зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
orange</b></td><td  bgcolor=""#ffffff"">
оранжевый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
orange red</b></td><td  bgcolor=""#ffffff"">
оранжево-красный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
orangey</b></td><td  bgcolor=""#ffffff"">
светло-оранжевый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
oyster white</b></td><td  bgcolor=""#ffffff"">
серовато-белый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale goldenrod</b></td><td  bgcolor=""#ffffff"">
бледно-золотистый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale green</b></td><td  bgcolor=""#ffffff"">
бледно-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale pink</b></td><td  bgcolor=""#ffffff"">
бледно-розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale turquoise</b></td><td  bgcolor=""#ffffff"">
бледно-бирюзовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale violet red</b></td><td  bgcolor=""#ffffff"">
красно-фиолетовый бледный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pale yellow</b></td><td  bgcolor=""#ffffff"">
бледно-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
peach</b></td><td  bgcolor=""#ffffff"">
персиковый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
peachpuff</b></td><td  bgcolor=""#ffffff"">
персиковый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pearl</b></td><td  bgcolor=""#ffffff"">
жемчужный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
petunia</b></td><td  bgcolor=""#ffffff"">
темно-лиловый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pewter</b></td><td  bgcolor=""#ffffff"">
оловянный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
photo magenta</b></td><td  bgcolor=""#ffffff"">
светло-пурпурный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pink</b></td><td  bgcolor=""#ffffff"">
розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pistachio</b></td><td  bgcolor=""#ffffff"">
фисташковый, зеленоватый цвет</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
plum</b></td><td  bgcolor=""#ffffff"">
сливовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
plum</b></td><td  bgcolor=""#ffffff"">
темно-фиолетовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
powder blue</b></td><td  bgcolor=""#ffffff"">
синий с пороховым оттенком</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
primrose</b></td><td  bgcolor=""#ffffff"">
лимонный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
pumpkin</b></td><td  bgcolor=""#ffffff"">
цвет тыквы</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
purple</b></td><td  bgcolor=""#ffffff"">
пурпурный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
purple</b></td><td  bgcolor=""#ffffff"">
фиолетовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
raspberry</b></td><td  bgcolor=""#ffffff"">
малиновый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
red</b></td><td  bgcolor=""#ffffff"">
красный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
rose</b></td><td  bgcolor=""#ffffff"">
цвет розы</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
rosy</b></td><td  bgcolor=""#ffffff"">
розовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
rosy brown</b></td><td  bgcolor=""#ffffff"">
розово-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
royal blue</b></td><td  bgcolor=""#ffffff"">
королевский синий (чистый, яркий оттенок
синего)</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
rust</b></td><td  bgcolor=""#ffffff"">
ржавый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
saddle brown</b></td><td  bgcolor=""#ffffff"">
кожано-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
salmon</b></td><td  bgcolor=""#ffffff"">
лососевый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
sand</b></td><td  bgcolor=""#ffffff"">
песочный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
seafoam</b></td><td  bgcolor=""#ffffff"">
цвет морской пены</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
seagreen</b></td><td  bgcolor=""#ffffff"">
цвет морской волны</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
seashell</b></td><td  bgcolor=""#ffffff"">
морская раковина</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
sienna</b></td><td  bgcolor=""#ffffff"">
охра</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
silver</b></td><td  bgcolor=""#ffffff"">
серебряный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
silvery</b></td><td  bgcolor=""#ffffff"">
серебряный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
sky blue</b></td><td  bgcolor=""#ffffff"">
небесно-голубой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
slate</b></td><td  bgcolor=""#ffffff"">
синевато-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
slate blue</b></td><td  bgcolor=""#ffffff"">
грифельно-синий</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
slate gray</b></td><td  bgcolor=""#ffffff"">
синевато-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
smoke blue</b></td><td  bgcolor=""#ffffff"">
бледный серо-голубой</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
snow</b></td><td  bgcolor=""#ffffff"">
белоснежный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
spice orange</b></td><td  bgcolor=""#ffffff"">
оранжевый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
spring green</b></td><td  bgcolor=""#ffffff"">
весенне-зеленый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
steel blue</b></td><td  bgcolor=""#ffffff"">
синий со стальным оттенком</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
steel gray</b></td><td  bgcolor=""#ffffff"">
стальной серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
tan</b></td><td  bgcolor=""#ffffff"">
желтовато-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
tan</b></td><td  bgcolor=""#ffffff"">
рыжевато-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
tanned</b></td><td  bgcolor=""#ffffff"">
бронзовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
taupe</b></td><td  bgcolor=""#ffffff"">
серо-коричневый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
taupe</b></td><td  bgcolor=""#ffffff"">
темно-серый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
tawny</b></td><td  bgcolor=""#ffffff"">
темно-желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
terra cotta</b></td><td  bgcolor=""#ffffff"">
терракотовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
turquoise</b></td><td  bgcolor=""#ffffff"">
бирюзовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
vinous</b></td><td  bgcolor=""#ffffff"">
бордовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
violet</b></td><td  bgcolor=""#ffffff"">
фиолетовый, темно-лиловый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
violet red</b></td><td  bgcolor=""#ffffff"">
красно-фиолетовый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
wheat</b></td><td  bgcolor=""#ffffff"">
пшеничный</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
white</b></td><td  bgcolor=""#ffffff"">
белый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
yellow</b></td><td  bgcolor=""#ffffff"">
желтый</td>
</tr>
<tr><td bgcolor=""#FFFFDD""><b> 
yellow green</b></td><td  bgcolor=""#ffffff"">
желто-зеленый</td>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishCharacterHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	амбициозный, целеустремленный</b></td><td> ambitious, high-flying
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	безумный</b></td><td> reckless
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	беспечный</b></td><td> light-hearted
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бешеный</b></td><td> furious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	волевой</b></td><td> strong-willed
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ворчливый</b></td><td> grumbling
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гордый</b></td><td> proud
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	гуманный</b></td><td> humane
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	добрый</b></td><td> kind
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	жадный</b></td><td> greedy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	желчный</b></td><td> acrimonious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	жестокий</b></td><td> cruel
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	завистливый</b></td><td> envious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	замкнутый</b></td><td> unsociable
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	заносчивый, высокомерный</b></td><td> arrogant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	злой</b></td><td> angry
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	идеальный</b></td><td> ideal
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	капризный</b></td><td> capricious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	коварный, хитрый</b></td><td> sly
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ленивый</b></td><td> lazy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лживый</b></td><td> lying
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	личность</b></td><td> personality
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	любопытный</b></td><td> curious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мерзкий</b></td><td> disgusting
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	наглый</b></td><td> impertinent
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	надежный, верный</b></td><td> reliable
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	назойливый</b></td><td> importunate
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	наивный</b></td><td> naive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	непослушный, капризный (о ребенке)</b></td><td> naughty
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	обидчивый</b></td><td> touchy
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	озорной</b></td><td> mischievous
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	оптимист</b></td><td> optimist
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	остроумный</b></td><td> witty
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	отважный</b></td><td> courageous
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ответственный</b></td><td> responsible
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	отзывчивый</b></td><td> responsive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пассивный</b></td><td> passive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пессимист</b></td><td> pessimist
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	позитивный</b></td><td> positive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	покладистый</b></td><td> complaisant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	равнодушный</b></td><td> indifferent
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	разумный, сообразительный</b></td><td> smart
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	раскованный</b></td><td> uninhibited
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рассудительный</b></td><td> sober-minded
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	реалист</b></td><td> realist
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	резкий</b></td><td> harsh
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	самокритичный</b></td><td> self-critical
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	самолюбивый</b></td><td> selfish
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	серьезный</b></td><td> serious
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	склад ума</b></td><td>  mentality
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	скромный</b></td><td> modest
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	смелый</b></td><td> brave
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	справедливый</b></td><td> fair
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	талантливый</b></td><td> talented
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	темперамент</b></td><td> temperament
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	терпеливый</b></td><td> patient
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тихий</b></td><td> quiet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	толерантный</b></td><td> tolerant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тупой</b></td><td> stupid
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	умный</b></td><td> clever
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	умный, разумный</b></td><td> intelligent
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	упрямый</b></td><td> stubborn
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	циничный</b></td><td> cynical
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	черта характера</b></td><td> character trait
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чувствительный</b></td><td> sensitive
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	щедрый</b></td><td> generous
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishProfessionsHTML = @"
<tr><td bgcolor=""#FFFFDD"" ><b>	accountant 	</b></td><td>	бухгалтер	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	actor  	</b></td><td>	актер 	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	architect 	</b></td><td>	архитектор	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	astronomer 	</b></td><td>	астроном	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	author 	</b></td><td>	автор (писатель)	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	baker 	</b></td><td>	пекарь	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	bricklayer 	</b></td><td>	каменщик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	bus driver 	</b></td><td>	водитель автобуса	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	butcher 	</b></td><td>	мясник	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	carpenter 	</b></td><td>	плотник	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	chef  	</b></td><td>	шеф-повар / повар	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	cleaner 	</b></td><td>	уборщик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	dentist 	</b></td><td>	дантист	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	designer 	</b></td><td>	дизайнер	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	doctor 	</b></td><td>	врач	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	dustman  	</b></td><td>	мусорщик 	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	electrician 	</b></td><td>	электрик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	engineer 	</b></td><td>	инженер	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	factory worker 	</b></td><td>	заводской рабочий	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	farmer 	</b></td><td>	фермер	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	fireman  	</b></td><td>	пожарный	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	fisherman 	</b></td><td>	рыбак	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	florist 	</b></td><td>	флорист	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	gardener 	</b></td><td>	садовник	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	hairdresser 	</b></td><td>	парикмахер	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	journalist 	</b></td><td>	журналист	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	judge 	</b></td><td>	судья	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	lawyer 	</b></td><td>	адвокат	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	lecturer 	</b></td><td>	преподаватель	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	librarian 	</b></td><td>	библиотекарь	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	lifeguard 	</b></td><td>	спасатель (на водах)	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	mechanic 	</b></td><td>	механик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	model 	</b></td><td>	модель	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	newsreader 	</b></td><td>	диктор	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	nurse 	</b></td><td>	медсестра	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	optician 	</b></td><td>	оптик, офтальмолог	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	painter 	</b></td><td>	художник / маляр 	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	pharmacist 	</b></td><td>	фармацевт	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	photographer 	</b></td><td>	фотограф	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	pilot 	</b></td><td>	пилот	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	plumber 	</b></td><td>	водопроводчик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	politician 	</b></td><td>	политик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	policeman  	</b></td><td>	полицейский (м. р. / ж. р.) 	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	postman 	</b></td><td>	почтальон	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	receptionist 	</b></td><td>	регистратор / портье / секретарь	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	scientist 	</b></td><td>	ученый	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	secretary 	</b></td><td>	секретарь	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	shop assistant 	</b></td><td>	продавец	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	soldier 	</b></td><td>	солдат	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	tailor 	</b></td><td>	портной	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	taxi driver 	</b></td><td>	таксист	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	teacher 	</b></td><td>	учитель	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	translator 	</b></td><td>	переводчик	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	traffic warden 	</b></td><td>	инспектор дорожного движения	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	travel agent 	</b></td><td>	турагент	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	veterinary doctor (vet) 	</b></td><td>	ветеринарный врач (ветеринар)	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	waiter  	</b></td><td>	официант 	</td></tr>
<tr><td bgcolor=""#FFFFDD"" ><b>	window cleaner 	</b></td><td>	мойщик окон	</td></tr>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishClothingHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бархат 	</b></td><td>	 velvet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	белый		</b></td><td>	 white
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бельё 	</b></td><td>	 underwear
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	блузка 	</b></td><td>	 blouse
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ботинок 	</b></td><td>	 boot
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	браслет 	</b></td><td>	 bracelet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	брюки 	</b></td><td>	 trousers
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	булавка 	</b></td><td>	 pin
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	бумажник 	</b></td><td>	 wallet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	воротник 	</b></td><td>	 collar
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	вуаль 	</b></td><td>	 veil
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	галстук 	</b></td><td>	 tie
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	грубый 	</b></td><td>	 rough
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	губная помада 	</b></td><td>	 lipstick
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	джинсы 	</b></td><td>	 jeans
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	длинный 	</b></td><td>	 long
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	духи 	</b></td><td>	 	perfume
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	жёлтый 	</b></td><td>	 yellow
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	жилет 		</b></td><td>	 waistcoat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	завязывать / завязать 	</b></td><td>	 to tie
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	застёгивать / застегнуть 	</b></td><td>	 to fasten
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	зелёный 	</b></td><td>	 green
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	зонтик 	</b></td><td>	 umbrella
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	игла 	</b></td><td>	 needle
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	изнашивать / износить 	</b></td><td>	 to wear out
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	карман 	</b></td><td>	 pocket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кожа 	</b></td><td>	 leather
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	колготки 	</b></td><td>	 tights
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кольцо 	</b></td><td>	 ring
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	коричневый 	</b></td><td>	 brown
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	короткий 	</b></td><td>	 short
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	костюм 	</b></td><td>	 suit
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кошелёк 	</b></td><td>	 purse
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	красить / покрасить 	</b></td><td>	 to dye
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	красный 	</b></td><td>	 red
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	кроссовки 	</b></td><td>	  running shoes
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	купальный костюм 	</b></td><td>	  swimsuit
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	куртка 	</b></td><td>	  jacket
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	лифчик 	</b></td><td>	 bra
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	майка 	</b></td><td>	 undershirt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мех 	</b></td><td>	 fur
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	модный 	</b></td><td>	 fashionable
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	мягкий 	</b></td><td>	 soft
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	надевать / надеть 	</b></td><td>	 to put on
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нейлон 	</b></td><td>	 nylon
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	нитка 	</b></td><td>	 thread
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	носовой платок 	</b></td><td>	 handkerchief
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	носок 	</b></td><td>	 sock
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ночная сорочка 	</b></td><td>	 nightdress
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	обувь 	</b></td><td>	 footwear
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	одеваться / одеться 	</b></td><td>	 to dress 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	одежда 	</b></td><td>	 clothes
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	оранжевый 	</b></td><td>	 orange
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	очки 	</b></td><td>	glasses
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пальто 	</b></td><td>	 coat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	перчатка 	</b></td><td>	 glove
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	плавки 	</b></td><td>	 swimming trunks
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	платье 	</b></td><td>	 dress
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	плащ 	</b></td><td>	 raincoat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	подкладка 	</b></td><td>	 lining
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	портфель 	</b></td><td>	 briefcase
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	просторный 	</b></td><td>	 ample
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пуговица 	</b></td><td>	 button
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пуловер 	</b></td><td>	 pullover
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пурпурный 	</b></td><td>	 purple
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	пятно 	</b></td><td>	 spot
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	развязывать / развязать 	</b></td><td>	 to untie
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	раздеваться / раздеться 	</b></td><td>	 to undress 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	размер 	</b></td><td>	 size
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	расстёгивать / расстегнуть 	</b></td><td>	 to unfasten
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рвать 	</b></td><td>	 to tear
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ремень 	</b></td><td>	  belt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	розовый 	</b></td><td>	 pink
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рубашка 	</b></td><td>	 shirt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	рукав 	</b></td><td>	 sleeve
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	сандалия 	</b></td><td>	 sandal
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	серый		</b></td><td>	 grey
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	серьга 		</b></td><td>	 earring
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	синий		</b></td><td>	 blue
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	снимать / снять 	</b></td><td>	 to take off
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	солнцезащитные очки 	</b></td><td>	 sunglasses
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	спица 	</b></td><td>	 knitting needle
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	тесный 	</b></td><td>	 tight
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ткань 	</b></td><td>	 cloth
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	трусы 	</b></td><td>	 underpants
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	туфля 	</b></td><td>	 shoe
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	фиолетовый 	</b></td><td>	 violet
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	футболка 	</b></td><td>	 tee-shirt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	хлопок 	</b></td><td>	 cotton
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	цвет 	</b></td><td>	 colour
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	цепочка 	</b></td><td>	 chain
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чёрный 	</b></td><td>	 black
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чинить / починить 	</b></td><td>	 to repair
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	чулок 	</b></td><td>	 stocking
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шарф 	</b></td><td>	 scarf
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шёлк 	</b></td><td>	 silk
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шерсть 	</b></td><td>	 wool
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шить/сшить 	</b></td><td>	 to sew
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шляпа 	</b></td><td>	 hat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шнурок 	</b></td><td>	 lace
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шорты 	</b></td><td>	 shorts
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	шуба 	</b></td><td>	 fur coat
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	элегантный 	</b></td><td>	 elegant
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	юбка 	</b></td><td>	 skirt
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ювелирные изделия 	</b></td><td>	 jewellery
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishInsectsHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	насекомое	</b></td><td>	insect	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бабочка	</b></td><td>	butterfly 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	блоха	</b></td><td>	flea 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	божья коровка	</b></td><td>	lady-bird 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вошь	</b></td><td>	louse 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	гусеница	</b></td><td>	caterpillar 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жук	</b></td><td>	beetle 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клещ	</b></td><td>	tick	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	клоп	</b></td><td>	bug 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	комар	</b></td><td>	mosquito, gnat 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	куколка	</b></td><td>	chrysalis (pl. –ices), pupa (pl. -ae)	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мокрица	</b></td><td>	pill bug 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	моль	</b></td><td>	moth 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	москит	</b></td><td>	mosquito 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	муравей	</b></td><td>	ant 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	муха	</b></td><td>	fly 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	ночная бабочка	</b></td><td>	nocturnal moth 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	овод	</b></td><td>	gadfly 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	оса	</b></td><td>	wasp 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	паук	</b></td><td>	spider 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	пчела	</b></td><td>	bee 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	светлячок	</b></td><td>	lightning bug 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	скарабей	</b></td><td>	scarab 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	скорпион	</b></td><td>	scorpion 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сороконожка	</b></td><td>	centipede 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	стрекоза	</b></td><td>	dragon-fly 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	таракан (рыжий, прусак)	</b></td><td>	cockroach 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	термит	</b></td><td>	termite 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	тля	</b></td><td>	 aphid 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	трутень	</b></td><td>	drone 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	шмель	</b></td><td>	bumble bee 	</td></tr>";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishMusicHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	accordion </b></td><td> 	 аккордеон
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	album </b></td><td> 	 альбом
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bagpipe </b></td><td> 	 волынка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	balalaika </b></td><td> 	 балалайка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ballet </b></td><td> 	 балет
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	band </b></td><td> 	 группа
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bass </b></td><td> 	 контрабас
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	basson </b></td><td> 	 фагот
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	baton </b></td><td> 	 дирижерская палочка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bow </b></td><td> 	 смычок
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brass group </b></td><td> 	 ударные
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cello </b></td><td> 	 виолончель
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	chamber music </b></td><td> 	 камерная музыка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	clarinet </b></td><td> 	 кларнет
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	classical music </b></td><td> 	 классическая музыка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	composer </b></td><td> 	 композитор
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	concert </b></td><td> 	 концерт
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	conductor </b></td><td> 	 дирижер
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cymbals </b></td><td> 	 тарелки
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	drum </b></td><td> 	 барабан
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	drum sticks </b></td><td> 	 барабанные палочки
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	flute </b></td><td> 	 флейта
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	grand piano </b></td><td> 	 рояль
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	guitar </b></td><td> 	 гитара
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	harp </b></td><td> 	 арфа 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	horn </b></td><td> 	 рожок
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	instrumental music </b></td><td> 	 инструментальная музыка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	loudspeaker </b></td><td> 	 громкоговоритель
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	microphone </b></td><td> 	 микрофон 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	musician </b></td><td> 	 музыкант
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	oboe </b></td><td> 	 гобой 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	opera </b></td><td> 	 опера 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	orchestra </b></td><td> 	 оркестр
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	organ </b></td><td> 	 орган 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	percussion </b></td><td> 	 перкуссия, ударные инструменты 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	piano </b></td><td> 	 пианино 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	recital </b></td><td> 	 сольный концерт 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	saxophone </b></td><td> 	 саксофон
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	single </b></td><td> 	 песня 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	soloist </b></td><td> 	 солист 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	song </b></td><td> 	 песня 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	sound </b></td><td> 	 звук 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	string group </b></td><td> 	 струнные инструменты 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	symphony </b></td><td> 	 симфония 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	synthesizer </b></td><td> 	 синтезатор 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to accompany </b></td><td> 	 аккомпанировать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to compose </b></td><td> 	 писать музыку
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to transcribe </b></td><td> 	 записывать нотами
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	trombone </b></td><td> 	 тромбон
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	trumpet </b></td><td> 	 труба
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	tuba </b></td><td> 	 туба
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	video / clip</b></td><td>	видео-клип
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	viola </b></td><td> 	 альт
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	violin </b></td><td> 	 скрипка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	virtuoso </b></td><td> 	 виртуоз
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishFurnitureHTML = @"
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	абажур, плафон	</b></td><td>	lampshade	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	бар (мебель)	</b></td><td>	drinks cabinet	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	батарея отопления	</b></td><td>	radiator	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ваза	</b></td><td>	vase	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ванна	</b></td><td>	bath	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ведро	</b></td><td>	bucket	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	весы	</b></td><td>	scales	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	вешалка (для пальто)	</b></td><td>	coat stand	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	вешалка (плечики)	</b></td><td>	coat hanger	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	выключатель	</b></td><td>	light switch	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	газовая плита	</b></td><td>	gas stove	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	гардероб, платяной шкаф	</b></td><td>	wardrobe	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	гладильная доска	</b></td><td>	ironing board	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	дверной звонок	</b></td><td>	doorbell	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	дверь	</b></td><td>	door	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	двухместная кровать	</b></td><td>	double bed	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	диван	</b></td><td>	sofa	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	диван-кровать	</b></td><td>	sofa-bed	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	занавески	</b></td><td>	curtains	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	зеркало	</b></td><td>	mirror	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	картина	</b></td><td>	picture / painting	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	книжный шкаф	</b></td><td>	bookcase	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ковёр 	</b></td><td>	carpet	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	коврик	</b></td><td>	rug	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	колонки (аудио)	</b></td><td>	loudspeakers	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	комнатные растения	</b></td><td>	houseplants	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	комод	</b></td><td>	chest of drawers	</a></td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кофемолка	</b></td><td>	coffee mill	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кран (с водой)	</b></td><td>	tap	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кран с горячей водой	</b></td><td>	hot tap	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кран с холодной водой	</b></td><td>	cold tap	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кресло	</b></td><td>	armchair	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	кровать	</b></td><td>	bed	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ламинат	</b></td><td>	laminated flooring	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	лампа	</b></td><td>	lamp	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	лампочка	</b></td><td>	lightbulb	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	магнитола	</b></td><td>	stereo	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	метла, веник	</b></td><td>	broom	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	микроволновая печь	</b></td><td>	microwave (oven)	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	мусорное ведро	</b></td><td>	dustbin	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	наволочка	</b></td><td>	pillowcase	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	обои	</b></td><td>	wallpaper	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	одеяло	</b></td><td>	blanket	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	окно	</b></td><td>	window	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	пианино	</b></td><td>	piano	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	письменный стол	</b></td><td>	desk	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	подушка	</b></td><td>	pillow	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	подушка диванная	</b></td><td>	cushion	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	постер	</b></td><td>	poster	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	простыня	</b></td><td>	sheet	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	радио	</b></td><td>	radio	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	ремонт	</b></td><td>	renovation	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	розетка (электрическая)	</b></td><td>	socket	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	сервант, буфет 	</b></td><td>	sideboard	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	скатерть	</b></td><td>	tablecloth	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	смартфон	</b></td><td>	smartphone	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	стенной шкаф, буфет 	</b></td><td>	cupboard	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	стиральная машина	</b></td><td>	washing machine	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	стол	</b></td><td>	table	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	стул	</b></td><td>	chair	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	табурет	</b></td><td>	stool	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	труба	</b></td><td>	pipe	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	утюг	</b></td><td>	iron	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	фен	</b></td><td>	hairdryer	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	холодильник	</b></td><td>	fridge 	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	часы	</b></td><td>	clock	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	швабра	</b></td><td>	mop	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	штепсель, вилка (электрическая)	</b></td><td>	plug	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	шторы	</b></td><td>	blinds	</td></tr>
<tr><td height=""24"" bgcolor=""#FFFFDD""><b>	щетка	</b></td><td>	brush	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishBushesHTML = @"
<tr><td bgcolor=""#FFFFDD""><b>	кустарник. куст	</b></td><td>	bush	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	боярышник	</b></td><td>	haw-thorn 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	бузина	</b></td><td>	elder 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	вереск	</b></td><td>	heather 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	дрок	</b></td><td>	genista 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жасмин	</b></td><td>	jasmine	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	жимолость	</b></td><td>	honey-suckle 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	кизил	</b></td><td>	Cornelian cherry 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	мушмула	</b></td><td>	medlar 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	облепиха	</b></td><td>	sea-buckthorn 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	олеандр	</b></td><td>	oleander 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	орешник	</b></td><td>	nut-grove 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	плющ	</b></td><td>	ivy 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	самшит	</b></td><td>	box-tree 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	сирень	</b></td><td>	lilac bush 	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	терновник	</b></td><td>	blackthorn	</td></tr>
<tr><td bgcolor=""#FFFFDD""><b>	шиповник	</b></td><td>	dog-rose, rose hips 	</td></tr>
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishComputerHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ability</b></td><td> способность, возможность
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	accurate </b></td><td> точный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to affect</b></td><td> воздействовать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	approximately</b></td><td> приблизительно
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to attain</b></td><td> достигать 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	available</b></td><td> доступный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	broadband connection</b></td><td> выделенное подключение
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to browse</b></td><td> просматривать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	browser</b></td><td> браузер, окно просмотра
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to carry out</b></td><td> выполнять
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to count</b></td><td> считать, сосчитать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to crack</b></td><td> взломать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	dangerous</b></td><td> опасный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	data </b></td><td> данные, сведения
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	defense</b></td><td> оборона, защита
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to design</b></td><td> задумывать, придумывать, разрабатывать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to determine</b></td><td> определить
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	digital</b></td><td> цифровой
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	display</b></td><td> дисплей
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to download</b></td><td> загружать, скачать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to enable</b></td><td> давать возможность или право на ч-т
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to enhance</b></td><td> повышать, увеличивать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	essential</b></td><td> существенный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	except</b></td><td> за исключением, кроме
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to find</b></td><td> находить
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to handle</b></td><td> обращаться, иметь дело с
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to intercept</b></td><td> перехватить (сигнал и т.д.)
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	interface</b></td><td> интерфейс
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	keyboard</b></td><td> клавиатура
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	laptop</b></td><td> ноутбук
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to last</b></td><td> длиться
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	layman</b></td><td> непрофессионал, любитель, ламер
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	link</b></td><td> ссылка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to log in</b></td><td> входить, подключаться
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to matсh</b></td><td> подходить, соответствовать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	message</b></td><td> послание
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	memory</b></td><td> память
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	monitor</b></td><td> монитор
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	motherboard</b></td><td> материнская плата 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	network</b></td><td> сеть
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	obsolete</b></td><td> устаревший
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	overload</b></td><td> перегрузка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to perform</b></td><td> выполнять, осуществлять
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	player</b></td><td> проигрыватель
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	printer</b></td><td> принтер
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to provide</b></td><td> снабжать, доставлять; обеспечивать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	provider</b></td><td> провайдер, поставщик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	query</b></td><td> запрос, вопрос
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to receive </b></td><td> получать, принимать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	reliable</b></td><td> надежный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to respond</b></td><td> отвечать, реагировать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	scale</b></td><td> масштаб
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to scan</b></td><td> сканировать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	scanner</b></td><td> сканер
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	security</b></td><td> безопасность
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to send</b></td><td> отправлять
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	significant</b></td><td> значительный, важный, существенный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	site</b></td><td> сайт
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	society</b></td><td> общество
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to solve</b></td><td> решать, разрешать; находить выход
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	source</b></td><td> источник
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	speakers</b></td><td> колонки 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	storage</b></td><td> хранение
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to surf</b></td><td> просматривать различные сайты в сети
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	tool</b></td><td> инструмент, орудие
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to type</b></td><td> печатать, напечатать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to update</b></td><td> обновить
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	user</b></td><td> пользователь
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	voltage</b></td><td> напряжение 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	window</b></td><td> окно
    ";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishCareerHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	actress</b></td><td> 	 актриса
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	additional payment</b></td><td> 	 доплата                    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	administrator</b></td><td> 	 администратор
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	advance</b></td><td> 	 аванс
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	agent</b></td><td> 	 агент
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	agronomist</b></td><td> 	 агроном
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	analyst</b></td><td> 	 аналитик    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	announcer</b></td><td> 	 диктор 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	anthropologist</b></td><td> 	 антрополог
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	application</b></td><td> 	 заявление                   
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	appointment</b></td><td> 	 назначение   
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	archaeologist</b></td><td> 	 археолог
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	artist</b></td><td> 	  художник                                                             
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	autobiography</b></td><td> 	 автобиография
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	baker</b></td><td> 	 пекарь
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	banker</b></td><td> 	 банкир
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bankrupt</b></td><td> 	 банкрот                  
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bookbinder</b></td><td> 	 переплетчик           
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	book-keeper</b></td><td> 	 бухгалтер
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	boycott</b></td><td> 	 бойкот
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bribe</b></td><td> 	 взятка
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bribery</b></td><td> 	 взяточничество
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	bricklayer</b></td><td> 	 каменщик                    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brigade-leader</b></td><td>	бригадир
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brigade; team</b></td><td> 	 бригада
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	builder</b></td><td> 	 строитель
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	careerist</b></td><td> 	 карьерист
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	carpenter</b></td><td> 	 плотник
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cash</b></td><td> 	 наличность                
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cashier</b></td><td> 	 кассир                         
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	charity</b></td><td> 	 благотворительность
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	chemist</b></td><td> 	 аптекарь                 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	clerk</b></td><td> 	 конторщик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	decree</b></td><td> 	 декрет     
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	demotion</b></td><td> 	 понижение по службе    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	depositor</b></td><td> 	 вкладчик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	discharge pay</b></td><td> 	 выходное пособие
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	discharge</b></td><td> 	 увольнение
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	dismiss</b></td><td> 	 увольнять
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	earn</b></td><td> 	 зарабатывать          
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	earnings</b></td><td> 	 заработок                   
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	editor</b></td><td> 	 редактор
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	employer</b></td><td> 	 работодатель
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	investment</b></td><td> 	 вложение
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	exchange</b></td><td> 	 биржа
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ferryman</b></td><td> 	 паромщик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	form</b></td><td> 	 бланк
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	geologist</b></td><td> 	 геолог 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	watchman</b></td><td> 	 сторож; 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	gynaecologist</b></td><td> 	 гинеколог
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	hire</b></td><td> 	 нанимать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	hired</b></td><td> 	 наемный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	invent</b></td><td> 	 изобретатель              
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	janitor</b></td><td> 	 дворник    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	journalist</b></td><td> 	 журналист     
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lawyer</b></td><td> 	 адвокат, юрист
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	vacation;</b></td><td> 	 отпуск
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	librarian</b></td><td> 	 библиотекарь
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	loader</b></td><td> 	 грузчик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	midwife</b></td><td> 	 акушерка  
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	milkmaid</b></td><td> 	 доярка                      
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	permanent</b></td><td> 	 бессрочный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pilot</b></td><td> 	 пилот
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	porter</b></td><td> 	 носильщик
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	postman</b></td><td> 	 почтальон  
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	potter</b></td><td> 	 гончар 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	rent</b></td><td> 	 аренда                                 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	reprimand</b></td><td> 	 выговор 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	rеsume</b></td><td> 	 резюме
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	revolt</b></td><td> 	 бунт
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	salary</b></td><td> 	 жалование                
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	singer</b></td><td> 	 певец
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	shareholder</b></td><td> 	 акционер    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	shepherd</b></td><td> 	 пастух
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	shoemaker</b></td><td> 	 сапожник
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	short-term</b></td><td> 	 краткосрочный                                
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	stock exchange</b></td><td> 	 фондовая биржа
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	strike</b></td><td> 	 забастовка                 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	strike</b></td><td> 	 бастовать              
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	renter</b></td><td> 	 арендатор  
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	trainer</b></td><td> 	 дрессировщик         
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	interpreter</b></td><td> 	 переводчик        
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	vacancy</b></td><td> 	 вакансия
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	vacant</b></td><td> 	 вакантный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	wage</b></td><td> 	 заработная плата    
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	waiter</b></td><td> 	 официант
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	unemployment</b></td><td> 	 безработица          
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	unemployed</b></td><td> 	 безработный
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringStudyEnglishArtHTML = @"
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	abstract art</b></td><td>абстракционизм	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	classical art</b></td><td>классическое искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	modern art</b></td><td>современное искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	primitive art</b></td><td>примитивизм	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	graphic art</b></td><td>графическое искусство, графика	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	antique art</b></td><td>античное искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	folk art</b></td><td>народное искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	decorative art</b></td><td>декоративное искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	applied art</b></td><td>прикладное искусство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pictorial art </b></td><td>живопись
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Classical Greek</b></td><td>древнегреческий	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Byzantine</b></td><td>византийский	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Flemish</b></td><td>фламандский	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Gothic</b></td><td>готический	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	the Renaissance period</b></td><td>эпоха Возрождения	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	the Baroque age</b></td><td>эпоха барокко	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	the Romantic era</b></td><td>эра Романтизма	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	the Neo-Classicists</b></td><td>неоклассицисты	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Impressionism</b></td><td>импрессионисты	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	The Symbolists</b></td><td>символисты	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Expressionism</b></td><td>экспрессионизм	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Cubism</b></td><td>кубизм	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Pop art</b></td><td>поп-арт	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	caricature</b></td><td>карикатура	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	collage</b></td><td>коллаж	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	drawing</b></td><td>рисунок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	engraving</b></td><td>гравюра, эстамп	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	landscape</b></td><td>пейзаж	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	marine </b></td><td>морской пейзаж	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	miniature</b></td><td>миниатюра	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	mosaics</b></td><td>мозаика	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	mural</b></td><td>фреска, настенная живопись	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	oil painting</b></td><td>картина маслом	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	self-portrait</b></td><td>автопортрет	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	sketch</b></td><td>набросок, этюд	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	still life</b></td><td>натюрморт	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	water-colour</b></td><td>живопись акварелью	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	painter</b></td><td>живописец, художник	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	artist</b></td><td>художник 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	landscape painter</b></td><td>пейзажист	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	portrait painter (portraitist)</b></td><td>портретист	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	colourist</b></td><td>художник-колорист	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	dauber</b></td><td>плохой художник	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	draughtsman </b></td><td>рисовальщик	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	colour-man</b></td><td>торговец красками	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	art-lover</b></td><td>любитель искусства	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	art-worker</b></td><td>художественный деятель	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	avant-garde</b></td><td>авангард	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	canvas</b></td><td>картина, полотно	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	painting</b></td><td>1) живопись, 2) картина	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	picture</b></td><td>1) картина, 2) фотография 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	exhibit </b></td><td>экспонат; выставлять,экспонировать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	art exhibition </b></td><td>художественная выставка	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	art gallery</b></td><td>художественная галерея	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brush</b></td><td>кисть	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	canvas</b></td><td>холст	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	chalk</b></td><td>мел	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	charcoal</b></td><td>угольный карандаш	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	colour box / palette</b></td><td>палитра	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	crayon</b></td><td>цветной карандаш, мелок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	easel</b></td><td>мольберт	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	frame</b></td><td>рама	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	fresco</b></td><td>фреска, фресковая живопись	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	gouache</b></td><td>гуашь	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ink</b></td><td>чернила	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lacquer</b></td><td>лак, глазурь	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	liquid</b></td><td>1) жидкость 2) жидкий	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	oil paint</b></td><td>масляная краска	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	paintbox</b></td><td>коробка с красками	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	panel</b></td><td>тонкая доска для живописи
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pigment</b></td><td>пигмент	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	vehicle</b></td><td>растворитель	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	watercolour</b></td><td>акварель	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	sketch-book </b></td><td>альбом, тетрадь для рисования	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	easel</b></td><td>мольберт	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Canvas </b></td><td>холст, картина, полотно 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	paint brush</b></td><td>кисть (для рисования)	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	paint oil</b></td><td>олифа	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	paint-box</b></td><td>коробка красок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lacquer</b></td><td>лак	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	solvent</b></td><td>растворитель;	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Paint </b></td><td>1) а) рисование б) рисунок;	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Sketch </b></td><td>эскиз, набросок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Colour 1. </b></td><td>  цвет 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	Picture</b></td><td>картина; рисунок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	piece</b></td><td>картина	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	life-size</b></td><td>размер в натуральную величину 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	half-life size</b></td><td>в половину натуральной величины	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	masterpiece</b></td><td>шедевр	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	scene</b></td><td>вид, пейзаж, картина	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	scenery</b></td><td>пейзаж 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	landscape</b></td><td>пейзаж; ландшафт 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	city-scape</b></td><td>городской пейзаж	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	portrait</b></td><td>портрет	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	miniature</b></td><td>миниатюра 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	caricature</b></td><td>карикатура	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	reproduction</b></td><td>репродукция, копия	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	prior art</b></td><td>прототип	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	panel</b></td><td>тонкая доска для живописи; 
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	fresco</b></td><td>фреска, фресковая живопись	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	chaotic</b></td><td>хаотичный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cheap</b></td><td>дешевый	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	crude</b></td><td>кричащий	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	depressing</b></td><td>унылый, тягостный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	disappointing</b></td><td>печальный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	fake</b></td><td>подделка; подлог, фальшивка	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	forgery</b></td><td>подделка, подлог, фальсификация, фальшивка 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	gaudy</b></td><td>яркий, безвкусный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	lyrical</b></td><td>лиричный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	masterpiece</b></td><td>шедевр	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	moving</b></td><td>трогательный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	obscure</b></td><td>мрачный, тусклый	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	original</b></td><td>оригинальный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	poetic</b></td><td>поэтичный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	romantic</b></td><td>романтичный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	unintelligible</b></td><td>неразборчивый	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	unsurpassed masterpiece</b></td><td>непревзойденный шедевр	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	vulgar</b></td><td>вульгарный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	аbstract</b></td><td>абстрактный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	abundance </b></td><td>обилие, изобилие	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	accuracy</b></td><td>точность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	affirmation</b></td><td>утверждение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	air</b></td><td>воздух	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	animation</b></td><td>живость	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	apotheosis</b></td><td>апофеоз	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	arrangement</b></td><td>расположение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	at one stroke </b></td><td>мгновенно	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	austere</b></td><td>суровый, строгий	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brilliance</b></td><td>яркость	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brushstroke</b></td><td>мазок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	candid glimpses</b></td><td> бледные отблески	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	colourful</b></td><td>яркий	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	colouring</b></td><td>колорит	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	conception</b></td><td>замысел	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cone</b></td><td>конус	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	craftsmanship</b></td><td>мастерство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	crystal-clear</b></td><td>чистый, прозрачный, ясный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	cuboid</b></td><td>кубический	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	decorative</b></td><td>декоративный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	decorativeness</b></td><td>декоративность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	delineation</b></td><td>очертание, эскиз	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	density</b></td><td>плотность, густота	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	design</b></td><td>композиция	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	effect</b></td><td>эффект, нечто броское, эффектное	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	emphasis</b></td><td>подчеркивание, акцент	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	expressiveness</b></td><td>выразительность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	exquisite</b></td><td>утонченный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	ffluent</b></td><td>плавный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	gamut</b></td><td>гамма	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	hyperbole</b></td><td>гипербола, преувеличение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	immediacy</b></td><td>непосредственность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	infinite</b></td><td>безграничный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	intensity</b></td><td>глубина красок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	intricate</b></td><td>запутанный, замысловатый	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	line</b></td><td>линия	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	luminous</b></td><td>прозрачный, светлый	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	original</b></td><td> 1) оригинал 2) оригинальный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	personification</b></td><td>олицетворение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	projection</b></td><td>проекция, отображение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	reproduction</b></td><td>репродукция	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	saturation</b></td><td>насыщенность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	semi-tones</b></td><td>полутона	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	silhouette</b></td><td>силуэт	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	simplicity</b></td><td>простота	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	skill</b></td><td>искусство, умение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	sphere</b></td><td>сфера	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	spirituality</b></td><td>одухотворенность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	subject</b></td><td>сюжет в живописи	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	texture</b></td><td>текстура	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to acquire</b></td><td>овладеть	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to affect</b></td><td>волновать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to anticipate</b></td><td>предвосхищать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to appeal</b></td><td>привлекать, влечь, взывать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to attain</b></td><td>достигать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to convey</b></td><td>передавать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to depict</b></td><td>изображать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to evoke</b></td><td>вызывать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to execute</b></td><td>исполнять	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to fade</b></td><td>блекнуть	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to frame</b></td><td>обрамлять	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to glorify</b></td><td>прославлять	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to grip</b></td><td>захватывать внимание	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to penetrate</b></td><td>проникать, пронизывать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to portray</b></td><td>изображать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to produce impression</b></td><td>производить впечатление	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to radiate</b></td><td>излучать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to render</b></td><td>изображать 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to restore</b></td><td>восстанавливать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to treat</b></td><td>трактовать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	tone</b></td><td>тон	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	treatment</b></td><td>трактовка	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	second-rate</b></td><td>второсортный, посредственный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	overrated</b></td><td>переоцененный, перехваленный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	revolting</b></td><td>отвратительный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	unremarkable</b></td><td>невыдающийся, обыкновенный
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pathetic</b></td><td>жалкий, убогий, ничтожный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	crude</b></td><td>сырой, неотработанный, предварительный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	sketchy</b></td><td>эскизный 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	poor</b></td><td>жалкий, ничтожный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	astonishing</b></td><td>удивительный, изумительный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	remarkable</b></td><td>замечательный, удивительный, выдающийся	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	superb</b></td><td>великолепный, грандиозный, 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brilliant</b></td><td>блестящий, выдающийся	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	great</b></td><td>замечательный, великолепный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	outstanding</b></td><td>выдающийся	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	brushstroke</b></td><td>мазок	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	stroke</b></td><td>штрих, мазок, черта	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	dab</b></td><td>мазок, пятно краски;	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to dab off</b></td><td>снимать легкими мазками	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	touch</b></td><td>штрих, черта
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	line</b></td><td>линия, черта, штрих	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	patch</b></td><td>пятно неправильной формы	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	artisic</b></td><td>художественный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	painterly</b></td><td>живописный, относящийся к живописи	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	impression</b></td><td>впечатление	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pictorial</b></td><td>живописный, изобразительный	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	picturesqueness</b></td><td>живописность	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	nude</b></td><td>обнаженное тело 	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	pose</b></td><td>поза; позировать художнику	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	profile</b></td><td>профиль, очертание, контур
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to execute</b></td><td>выполнять, исполнять	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	execution</b></td><td>мастерство исполнения	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	experience</b></td><td>квалификация, мастерство	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to express</b></td><td>выражать	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	expression</b></td><td>выразительность, экспрессия	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to render</b></td><td>воспроизводить, изображать
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	rendering</b></td><td>передача, изображение	
</td></tr><tr><td bgcolor=""#FFFFDD""><b>	to convey</b></td><td>передавать, выражать (идею и т. п.)	
        ";
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
