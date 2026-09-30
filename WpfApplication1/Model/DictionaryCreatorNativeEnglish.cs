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
        static public List<Word> CreateNativeEnglishPrepositionsFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Native-EnglishPrepositions",
@"<tr>\s*<td>\s*([^<]+)</td>\s*<td>\s*<span([^>]+)>([^<]+)</span>\s*</td>\s*</tr>",
//@"<tr>\s*<td>\s*([^<]+)</td>\s*<td>\s*<span([^>]+)>([^<]+)</span>\s*</td>\s*</tr>",
stringNativeEnglishPrepositionsHTML, 1, 3);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringNativeEnglishPrepositionsHTML = @"
<tr><td>
				aboard</td>
			<td>
				<span class=""rus"">на борту</span></td>
		</tr>
		<tr>
			<td>
				about</td>
			<td>
				<span class=""rus"">кругом, вокруг, о , относительно</span></td>
		</tr>
		<tr>
			<td>
				above</td>
			<td>
				<span class=""rus"">над, до, более, свыше, выше</span></td>
		</tr>
		<tr>
			<td>
				absent</td>
			<td>
				<span class=""rus"">без, в отсутствие</span></td>
		</tr>
		<tr>
			<td>
				across</td>
			<td>
				<span class=""rus"">через, сквозь, по ту сторону</span></td>
		</tr>
		<tr>
			<td>
				afore</td>
			<td>
				<span class=""rus"">вперед</span></td>
		</tr>
		<tr>
			<td>
				after</td>
			<td>
				<span class=""rus"">за, после, по, позади</span></td>
		</tr>
		<tr>
			<td>
				against</td>
			<td>
				<span class=""rus"">против, к</span></td>
		</tr>
		<tr>
			<td>
				along</td>
			<td>
				<span class=""rus"">вдоль, по</span></td>
		</tr>
		<tr>
			<td>
				amid</td>
			<td>
				<span class=""rus"">среди, посреди, между</span></td>
		</tr>
		<tr>
			<td>
				among</td>
			<td>
				<span class=""rus"">между, посреди</span></td>
		</tr>
		<tr>
			<td>
				amongst</td>
			<td>
				<span class=""rus"">между, посреди</span></td>
		</tr>
		<tr>
			<td>
				around</td>
			<td>
				<span class=""rus"">вокруг, по, около</span></td>
		</tr>
		<tr>
			<td>
				as</td>
			<td>
				<span class=""rus"">в качестве, как</span></td>
		</tr>
		<tr>
			<td>
				aside</td>
			<td>
				<span class=""rus"">в стороне, поодаль</span></td>
		</tr>
		<tr>
			<td>
				aslant</td>
			<td>
				<span class=""rus"">поперек</span></td>
		</tr>
		<tr>
			<td>
				astride</td>
			<td>
				<span class=""rus"">верхом на, по обе стороны, на пути</span></td>
		</tr>
		<tr>
			<td>
				at</td>
			<td>
				<span class=""rus"">у, около, в, на</span></td>
		</tr>
		<tr>
			<td>
				athwart</td>
			<td>
				<span class=""rus"">поперек, через, вопреки, против</span></td>
		</tr>
		<tr>
			<td>
				atop</td>
			<td>
				<span class=""rus"">на, поверх, над</span></td>
		</tr>
		<tr>
			<td>
				bar</td>
			<td>
				<span class=""rus"">исключая, за исключением, кроме</span></td>
		</tr>
		<tr>
			<td>
				before</td>
			<td>
				<span class=""rus"">перед, до, в</span></td>
		</tr>
		<tr>
			<td>
				behind</td>
			<td>
				<span class=""rus"">позади, за, после</span></td>
		</tr>
		<tr>
			<td>
				below</td>
			<td>
				<span class=""rus"">ниже, под</span></td>
		</tr>
		<tr>
			<td>
				beneath</td>
			<td>
				<span class=""rus"">под, ниже</span></td>
		</tr>
		<tr>
			<td>
				beside</td>
			<td>
				<span class=""rus"">рядом, близ, около, ниже</span></td>
		</tr>
		<tr>
			<td>
				besides</td>
			<td>
				<span class=""rus"">кроме</span></td>
		</tr>
		<tr>
			<td>
				between</td>
			<td>
				<span class=""rus"">между</span></td>
		</tr>
		<tr>
			<td>
				betwixt</td>
			<td>
				<span class=""rus"">между</span></td>
		</tr>
		<tr>
			<td>
				beyond</td>
			<td>
				<span class=""rus"">по ту сторону, вне, позже, сверх</span></td>
		</tr>
		<tr>
			<td>
				but</td>
			<td>
				<span class=""rus"">кроме, за исключением</span></td>
		</tr>
		<tr>
			<td>
				by</td>
			<td>
				<span class=""rus"">у, около, мимо, вдоль, через, к</span></td>
		</tr>
		<tr>
			<td>
				circa</td>
			<td>
				<span class=""rus"">приблизительно, примерно, около</span></td>
		</tr>
		<tr>
			<td>
				despite</td>
			<td>
				<span class=""rus"">несмотря на</span></td>
		</tr>
		<tr>
			<td>
				down</td>
			<td>
				<span class=""rus"">вниз, с, по течению, ниже</span></td>
		</tr>
		<tr>
			<td>
				except</td>
			<td>
				<span class=""rus"">исключая, кроме</span></td>
		</tr>
		<tr>
			<td>
				for</td>
			<td>
				<span class=""rus"">в течение дня, за, ради, по отношению. для </span></td>
		</tr>
		<tr>
			<td>
				from</td>
			<td>
				<span class=""rus"">от, из, с, по, из-за, у</span></td>
		</tr>
		<tr>
			<td>
				given</td>
			<td>
				<span class=""rus"">при условии</span></td>
		</tr>
		<tr>
			<td>
				in</td>
			<td>
				<span class=""rus"">в, во, на, в течение, через, из</span></td>
		</tr>
		<tr>
			<td>
				inside</td>
			<td>
				<span class=""rus"">внутри, внутрь</span></td>
		</tr>
		<tr>
			<td>
				into</td>
			<td>
				<span class=""rus"">в, на</span></td>
		</tr>
		<tr>
			<td>
				like</td>
			<td>
				<span class=""rus"">так; как что-л.; подобно чему-л.</span></td>
		</tr>
		<tr>
			<td>
				mid (от ""amid"")</td>
			<td>
				<span class=""rus"">между, посреди, среди</span></td>
		</tr>
		<tr>
			<td>
				minus</td>
			<td>
				<span class=""rus"">без, минус</span></td>
		</tr>
		<tr>
			<td>
				near</td>
			<td>
				<span class=""rus"">около, возле, к</span></td>
		</tr>
		<tr>
			<td>
				neath</td>
			<td>
				<span class=""rus"">под, ниже</span></td>
		</tr>
		<tr>
			<td>
				next</td>
			<td>
				<span class=""rus"">рядом, около</span></td>
		</tr>
		<tr>
			<td>
				notwithstanding</td>
			<td>
				<span class=""rus"">не смотря на, вопреки</span></td>
		</tr>
		<tr>
			<td>
				of</td>
			<td>
				<span class=""rus"">о, у, из, от</span></td>
		</tr>
		<tr>
			<td>
				off</td>
			<td>
				<span class=""rus"">с, со, от</span></td>
		</tr>
		<tr>
			<td>
				on</td>
			<td>
				<span class=""rus"">на, у, после, в</span></td>
		</tr>
		<tr>
			<td>
				opposite</td>
			<td>
				<span class=""rus"">против, напротив</span></td>
		</tr>
		<tr>
			<td>
				out</td>
			<td>
				<span class=""rus"">вне, из</span></td>
		</tr>
		<tr>
			<td>
				outside</td>
			<td>
				<span class=""rus"">вне, за пределами</span></td>
		</tr>
		<tr>
			<td>
				over</td>
			<td>
				<span class=""rus"">над, через, за, по, свыше</span></td>
		</tr>
		<tr>
			<td>
				pace</td>
			<td>
				<span class=""rus"">с позволения</span></td>
		</tr>
		<tr>
			<td>
				per</td>
			<td>
				<span class=""rus"">по, посредством, через, согласно</span></td>
		</tr>
		<tr>
			<td>
				plus</td>
			<td>
				<span class=""rus"">плюс, с</span></td>
		</tr>
		<tr>
			<td>
				post</td>
			<td>
				<span class=""rus"">после</span></td>
		</tr>
		<tr>
			<td>
				pro</td>
			<td>
				<span class=""rus"">для, ради, за</span></td>
		</tr>
		<tr>
			<td>
				qua</td>
			<td>
				<span class=""rus"">как, в качестве</span></td>
		</tr>
		<tr>
			<td>
				round</td>
			<td>
				<span class=""rus"">вокруг, по</span></td>
		</tr>
		<tr>
			<td>
				save</td>
			<td>
				<span class=""rus"">кроме, исключая</span></td>
		</tr>
		<tr>
			<td>
				since</td>
			<td>
				<span class=""rus"">с (некоторого времени), после</span></td>
		</tr>
		<tr>
			<td>
				than</td>
			<td>
				<span class=""rus"">нежели, чем</span></td>
		</tr>
		<tr>
			<td>
				through</td>
			<td>
				<span class=""rus"">через, сквозь, по, через посредство</span></td>
		</tr>
		<tr>
			<td>
				till</td>
			<td>
				<span class=""rus"">до</span></td>
		</tr>
		<tr>
			<td>
				times</td>
			<td>
				<span class=""rus"">на</span></td>
		</tr>
		<tr>
			<td>
				to</td>
			<td>
				<span class=""rus"">в, на, к, до, без</span></td>
		</tr>
		<tr>
			<td>
				toward</td>
			<td>
				<span class=""rus"">к, на, с тем чтобы, по отношению к</span></td>
		</tr>
		<tr>
			<td>
				under</td>
			<td>
				<span class=""rus"">под, ниже, при</span></td>
		</tr>
		<tr>
			<td>
				underneath</td>
			<td>
				<span class=""rus"">под</span></td>
		</tr>
		<tr>
			<td>
				unlike</td>
			<td>
				<span class=""rus"">в отличие от</span></td>
		</tr>
		<tr>
			<td>
				until</td>
			<td>
				<span class=""rus"">до</span></td>
		</tr>
		<tr>
			<td>
				up</td>
			<td>
				<span class=""rus"">вверх, по</span></td>
		</tr>
		<tr>
			<td>
				versus (сокр. «vs.»)</td>
			<td>
				<span class=""rus"">против, в сравнении с, в отличие от</span></td>
		</tr>
		<tr>
			<td>
				via</td>
			<td>
				<span class=""rus"">через</span></td>
		</tr>
		<tr>
			<td>
				vice</td>
			<td>
				<span class=""rus"">взамен, вместо</span></td>
		</tr>
		<tr>
			<td>
				with</td>
			<td>
				<span class=""rus"">с, в, от</span></td>
		</tr>
		<tr>
			<td>
				without</td>
			<td>
				<span class=""rus"">вне, без, за, не сделав чего-либо</span></td>
		</tr>
		<tr>
			<td colspan=""2"">
				<div class=""center"">
					<b>Производные</b></div>
			</td>
		</tr>
		<tr>
			<td>
				barring</td>
			<td>
				<span class=""rus"">исключая, за исключением, кроме</span></td>
		</tr>
		<tr>
			<td>
				concerning</td>
			<td>
				<span class=""rus"">относительно</span></td>
		</tr>
		<tr>
			<td>
				considering</td>
			<td>
				<span class=""rus"">учитывая, принимая во внимание</span></td>
		</tr>
		<tr>
			<td>
				depending</td>
			<td>
				<span class=""rus"">в зависимости</span></td>
		</tr>
		<tr>
			<td>
				during</td>
			<td>
				<span class=""rus"">в течение, в продолжение, во время</span></td>
		</tr>
		<tr>
			<td>
				granted</td>
			<td>
				<span class=""rus"">при условии</span></td>
		</tr>
		<tr>
			<td>
				excepting</td>
			<td>
				<span class=""rus"">за исключением, исключая</span></td>
		</tr>
		<tr>
			<td>
				excluding</td>
			<td>
				<span class=""rus"">за исключением</span></td>
		</tr>
		<tr>
			<td>
				failing</td>
			<td>
				<span class=""rus"">за неимением, в случае отсутствия</span></td>
		</tr>
		<tr>
			<td>
				following</td>
			<td>
				<span class=""rus"">после, вслед за</span></td>
		</tr>
		<tr>
			<td>
				including</td>
			<td>
				<span class=""rus"">включая, в том числе</span></td>
		</tr>
		<tr>
			<td>
				past</td>
			<td>
				<span class=""rus"">за, после, мимо, сверх, выше</span></td>
		</tr>
		<tr>
			<td>
				pending</td>
			<td>
				<span class=""rus"">в продолжение, в течение, до, вплоть</span></td>
		</tr>
		<tr>
			<td>
				regarding</td>
			<td>
				<span class=""rus"">относительно, касательно</span></td>
		</tr>
		<tr>
			<td colspan=""2"">
				<div class=""center"">
					<b>Сложные</b></div>
			</td>
		</tr>
		<tr>
			<td>
				alongside</td>
			<td>
				<span class=""rus"">около, рядом, у</span></td>
		</tr>
		<tr>
			<td>
				within</td>
			<td>
				<span class=""rus"">внутри, внутрь, в пределах</span></td>
		</tr>
		<tr>
			<td>
				outside</td>
			<td>
				<span class=""rus"">вне, за пределами, за исключением</span></td>
		</tr>
		<tr>
			<td>
				upon</td>
			<td>
				<span class=""rus"">на, у, после, в</span></td>
		</tr>
		<tr>
			<td>
				onto</td>
			<td>
				<span class=""rus"">на, в</span></td>
		</tr>
		<tr>
			<td>
				throughout</td>
			<td>
				<span class=""rus"">через, на всем протяжении</span></td>
		</tr>
		<tr>
			<td>
				wherewith</td>
			<td>
				<span class=""rus"">чем, посредством которого</span></td>
		</tr>
		<tr>
			<td colspan=""2"">
				<div class=""center"">
					<b>Составные</b></div>
			</td>
		</tr>
		<tr>
			<td>
				according to</td>
			<td>
				<span class=""rus"">согласно</span></td>
		</tr>
		<tr>
			<td>
				ahead of</td>
			<td>
				<span class=""rus"">до, в преддверии</span></td>
		</tr>
		<tr>
			<td>
				apart from</td>
			<td>
				<span class=""rus"">несмотря на, невзирая на</span></td>
		</tr>
		<tr>
			<td>
				as far as</td>
			<td>
				<span class=""rus"">до</span></td>
		</tr>
		<tr>
			<td>
				as for</td>
			<td>
				<span class=""rus"">что касается</span></td>
		</tr>
		<tr>
			<td>
				as of</td>
			<td>
				<span class=""rus"">с, начиная с; на день, на дату; </span></td>
		</tr>
		<tr>
			<td>
				as per</td>
			<td>
				<span class=""rus"">согласно</span></td>
		</tr>
		<tr>
			<td>
				as regards</td>
			<td>
				<span class=""rus"">что касается, в отношении</span></td>
		</tr>
		<tr>
			<td>
				aside from</td>
			<td>
				<span class=""rus"">помимо, за исключением</span></td>
		</tr>
		<tr>
			<td>
				as well as</td>
			<td>
				<span class=""rus"">кроме, наряду</span></td>
		</tr>
		<tr>
			<td>
				away from</td>
			<td>
				<span class=""rus"">от, в отсутствие</span></td>
		</tr>
		<tr>
			<td>
				because of</td>
			<td>
				<span class=""rus"">из-за</span></td>
		</tr>
		<tr>
			<td>
				by force of</td>
			<td>
				<span class=""rus"">в силу</span></td>
		</tr>
		<tr>
			<td>
				by means of</td>
			<td>
				<span class=""rus"">посредством</span></td>
		</tr>
		<tr>
			<td>
				by virtue of</td>
			<td>
				<span class=""rus"">в силу, на основании</span></td>
		</tr>
		<tr>
			<td>
				close to</td>
			<td>
				<span class=""rus"">рядом с</span></td>
		</tr>
		<tr>
			<td>
				contrary to</td>
			<td>
				<span class=""rus"">против, вопреки</span></td>
		</tr>
		<tr>
			<td>
				due to</td>
			<td>
				<span class=""rus"">благодаря, в силу, из-за</span></td>
		</tr>
		<tr>
			<td>
				except for</td>
			<td>
				<span class=""rus"">кроме</span></td>
		</tr>
		<tr>
			<td>
				far from</td>
			<td>
				<span class=""rus"">далеко не</span></td>
		</tr>
		<tr>
			<td>
				for the sake of</td>
			<td>
				<span class=""rus"">ради</span></td>
		</tr>
		<tr>
			<td>
				in accordance with</td>
			<td>
				<span class=""rus"">в соответствии с</span></td>
		</tr>
		<tr>
			<td>
				in addition to</td>
			<td>
				<span class=""rus"">в дополнение, кроме</span></td>
		</tr>
		<tr>
			<td>
				in case of</td>
			<td>
				<span class=""rus"">в случае</span></td>
		</tr>
		<tr>
			<td>
				in connection with</td>
			<td>
				<span class=""rus"">в связи с</span></td>
		</tr>
		<tr>
			<td>
				in consequence of</td>
			<td>
				<span class=""rus"">вследствие, в результате</span></td>
		</tr>
		<tr>
			<td>
				in front of</td>
			<td>
				<span class=""rus"">впереди</span></td>
		</tr>
		<tr>
			<td>
				in spite of</td>
			<td>
				<span class=""rus"">несмотря на</span></td>
		</tr>
		<tr>
			<td>
				in the back of</td>
			<td>
				<span class=""rus"">сзади, позади</span></td>
		</tr>
		<tr>
			<td>
				in the course of</td>
			<td>
				<span class=""rus"">в течение</span></td>
		</tr>
		<tr>
			<td>
				in the event of</td>
			<td>
				<span class=""rus"">в случае, если</span></td>
		</tr>
		<tr>
			<td>
				in the middle of</td>
			<td>
				<span class=""rus"">посередине</span></td>
		</tr>
		<tr>
			<td>
				in to (into)</td>
			<td>
				<span class=""rus"">в, на</span></td>
		</tr>
		<tr>
			<td>
				inside of</td>
			<td>
				<span class=""rus"">за (какое-л время), в течение</span></td>
		</tr>
		<tr>
			<td>
				instead of</td>
			<td>
				<span class=""rus"">вместо</span></td>
		</tr>
		<tr>
			<td>
				in view of</td>
			<td>
				<span class=""rus"">ввиду</span></td>
		</tr>
		<tr>
			<td>
				near to</td>
			<td>
				<span class=""rus"">рядом, поблизости</span></td>
		</tr>
		<tr>
			<td>
				next to</td>
			<td>
				<span class=""rus"">рядом, поблизости</span></td>
		</tr>
		<tr>
			<td>
				on account of</td>
			<td>
				<span class=""rus"">по причине, из-за, вследствие</span></td>
		</tr>
		<tr>
			<td>
				on to (onto)</td>
			<td>
				<span class=""rus"">на</span></td>
		</tr>
		<tr>
			<td>
				on top of</td>
			<td>
				<span class=""rus"">на вершине, наверху</span></td>
		</tr>
		<tr>
			<td>
				opposite to</td>
			<td>
				<span class=""rus"">против</span></td>
		</tr>
		<tr>
			<td>
				out of</td>
			<td>
				<span class=""rus"">из, изнутри, снаружи, за пределами</span></td>
		</tr>
		<tr>
			<td>
				outside of</td>
			<td>
				<span class=""rus"">вне, помимо</span></td>
		</tr>
		<tr>
			<td>
				owing to</td>
			<td>
				<span class=""rus"">из-за, благодаря</span></td>
		</tr>
		<tr>
			<td>
				thanks to</td>
			<td>
				<span class=""rus"">благодаря</span></td>
		</tr>
		<tr>
			<td>
				up to</td>
			<td>
				<span class=""rus"">вплоть до, на уровне</span></td>
		</tr>
		<tr>
			<td>
				with regard to</td>
			<td>
				<span class=""rus"">относительно, по отношению</span></td>
		</tr>
		<tr>
			<td>
				with respect to</td>
			<td>
				<span class=""rus"">относительно, по отношению</span></td>
		</tr>
";
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
