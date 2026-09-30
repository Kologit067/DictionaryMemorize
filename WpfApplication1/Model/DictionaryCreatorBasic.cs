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
        static public List<Word> CreateBasicWordPictureFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Basic-WordPicturet",
@"(\w+)\s+-\s+(\w+)", stringBasicWordPictureHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateBasicCommonFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Basic-Common",
@"(\w+)\s+-\s+(\w+)", stringBasicCommonHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateBasicActionFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Basic-Action",
@"(\w+)\s+-\s+(\w+)", stringBasicActionHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateBasicQualityFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Basic-Quality",
@"(\w+)\s+-\s+(\w+)", stringBasicQualityHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Word> CreateBasicOppositeFromHTML(Dictionary<string, List<Word>> WordDictionary)
        {
            return CreateDictFromTextByRegex(WordDictionary, "Basic-Opposite",
@"(\w+)\s+-\s+(\w+)", stringBasicOppositeHTML, 1, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringBasicOppositeHTML = @"
A:
awake - активный, пробуждать, просыпаться 	  	 

B:
bad - плохой
bent - склонность, сгибать 	bitter - горький, ожесточенный
blue - синий 	 

Скрыть 50 слов-картинок

C:
certain - уверенный, определенный
cold - холодный 	complete - полный, заканчивать
cruel - жестокий 	 

D:
dark - темнота, темный
dead - мёртвый
dear - дорогой 	delicate - тонкий, деликатный
different - различный, другой
dirty - грязный 	dry - сухой, сушить

F:
false - фальшивый
feeble - слабый 	female - женский
foolish - глупый 	future - будущий, будущее

G:
green - зелёный 	  	 

I:
ill - плохо, болеть 	  	 

L:
last - последний, длиться
late - опаздывать 	left - лево, левый
loose - свободный, освобождать 	loud - громкий
low - низкий

M:
mixed - перемешанный 	  	 

N:
narrow - узкий, сужаться 	  	 

O:
old - старый
opposite - напротив, противоположный 	 

P:
public - публичный 	  	 

R:
rough - грубый 	  	 

S:
sad - расстроенный
safe - безопасный
secret - секретный
short - короткий 	simple - простой
slow - медленный
small - маленький
soft - мягкий 	solid - твёрдый, солидный
special - специальный
strange - странный

T:
thin - худой, тонкий, жидкий 	  	 

W:
white - белый 
wrong - неправильный, несправедливость";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringBasicQualityHTML = @"
A:
able - способный, быть в состоянии 	acid - кислота, кислый 	angry - сердитый

B:
beautiful - красивый
black - чёрный 	boiling - кипение
bright - яркий, умный 	broken - сломанный
brown - коричневый

Скрыть 100 слов-картинок

C:
cheap - дешёвый
chemical - химикат
chief - главный 	clean - чистый, чистить
clear - ясный, очищать, оправдываться
common - общий 	complex - комплекс
conscious - сознательный
cut - резать

D:
deep - глубокий, глубоко 	dependent - зависимый 	 

E:
early - рано, ранний 	elastic - эластичный 	equal - равный, равняться

F:
fat - толстый, жир
fertile - плодородный
first - первый 	fixed - неподвижный, неизменный
flat - плоский, квартира, плоскость
free - свобода, бесплатный 	frequent - частый, часто посещать
full - полный

G:
general - общий, генерал
good - хороший 	great - великий, великолепный
grey|gray - серый 	 

H:
hanging - вывешивание, висение
happy - счастье 	hard - трудный, тяжёлый, твёрдый
healthy - здоровый 	high - высокий, высоко
hollow - пустота

I:
important - важный 	  	 

J:
jewel - драгоценный камень 	  	 

K:
kind - добрый, вид 	  	 

L:
like - подобный, любить, нравиться 	living - проживаниe 	long - долго, длинный

M:
male - мужской, мужчина
married - женатый, замужем 	material - материал
medical - медицинский 	military - военный

N:
natural - натуральный
necessary - необходимый 	new - новый
normal - нормальный 	 

O:
open - открытый, открывать 	  	 

P:
parallel - параллельный, находить что-либо подобное 
past - мимо, прошлый
physical - физический 	political - политический
poor - бедный, плохой, слабый
possible - возможный 	present - существующий, подарок
private - личный, приватный
probable - вероятный

Q:
quick - быстрый
quiet - тихий, успокаивать 	  	 

R:
ready - готовый, готов
read - читать 	regular - регулярный
responsible - ответственный 	right - верный, право
round - вокруг, круглый, раунд

S:
same - то же самое
second - секунда, второй
separate - отдельный, отделять
serious - серьёзный 	sharp - острый
smooth - гладкий, мягкий, приглаживать
sticky - липкий
stiff - жесткий 	straight - прямой
strong - сильный
sudden - внезапный
sweet - сладкий

T:
tall - высокий
thick - толстый, густой 	tight - трудный
tired - усталый 	true - правда, правдивый

V:
violent - сильный, жестокий 	  	 

W:
waiting - ожидание
warm - теплый, нагревать 	wet - влажный
wide - широкий 	wise - мудрый

Y:
yellow - жёлтый
young - молодой";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringBasicActionHTML = @"
come - приходить, приезжать
get - получать, заставлять
give - давать
go - ходить, идти
keep - продолжать, держать, оставлять, не допускать
let - позволять
make - делать/сделать, заставлять
put - помещать
seem - казаться, представляться
take - брать/взять
be - быть
do - делать
have - иметь, съесть, знать
say - говорить
see - видеть
send - посылать
may - мочь
will - быть хотеть
about - о
across - через
after - после
against - против
among - среди
at - в
before - перед
between - между
by - к, в соответствии с, за, на
down - вниз
from - из
in - в
off - прочь, от
on - на
over - по
through - через 	to - к, до, в
under - под
up - вверх
with - с
as - поскольку, как
for - для
of - из, о, от
till - пока, до
than - чем
a - любой, один, каждый, некий
the  
all - все, весь
any - любой, никто
every - каждый
no - никакой, нет
other - другой
some - некоторый, немного
such - такой, таким образом
that - что
this - это, этот
i - я
he - он
you - ты, вы
who - кто
and - и
because - потому что
but - а, но
or - или
if - если
though - хотя
while - в то время как
how - как
when - когда
where - где, куда, откуда 	why - почему
again - снова
ever - когда-либо, никогда
far - самый дальний
forward - отправлять, вперед
here - здесь, сюда
near - рядом, около
now - теперь, сейчас
out - вне, снаружи 
still - все еще
then - тогда
there - там, туда
together - вместе
well - хорошо, намного
almost - почти
enough - достаточно
even - еще, даже
little - маленький
much - много
not - не
only - только
quite - весьма
so - так
very - очень
tomorrow - завтра
yesterday - вчера
north - север
south - юг
east - восток
west - запад
please - пожалуйста
yes - да
";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringBasicCommonHTML = @"
A:
account - счет, считать
act - действия
addition - дополнение
adjust - регулировать, приспосабливать
advertisement - реклама
agreement - соглашение
air - воздух, проветривать 	amount - количество, означать, составлять
amusement - развлечение
animal - животное
answer - ответ, отвечать
apparatus - аппарат
approval - одобрение
argument - спор, аргумент 	art - искусство, художественный
attack - нападение, нападать
attempt - попытка, пытаться
attention - внимание
attraction - достопримечательности
authority - власть, полномочие

B:
back - назад, спина, отступать
balance - баланс, уравновешивать
base - основной
behavior - поведение
belief - вера
birth - рождение
bit - частица, бит 	bite - укус, кусать
blood - кровь
blow - удар, дуть
body - тело
brass - медь, руководство
bread - хлеб
breath - дыхание 	brother - брат
building - здание, строение
burn - ожог, гореть
burst - взрыв, взрывать
business - бизнес, деловой
butter - масло


C:
canvas - холст
care - забота, лечение
cause - причина, вызывать
chalk - мел, рисовать мелом
chance - шанс, случайный, рисковать
change - изменение, замена
cloth - ткань, одежда
coal - уголь
color - цвет
comfort - комфорт
committee - комитет 	company - компания
comparison - сравнение
competition - соревнование
condition - условие, обуславливать
connection - связь
control - контроль
cook - готовить
copper - медь
copy - копия
cork - пробка
cotton - хлопок 	cough - кашель
country - страна
cover - покрытие, покрывать, обложка
crack - первоклассный, взламывать
credit - кредит, верить
crime - преступление
crush - давка, сокрушать
cry - плакать
current - текущий, поток
curve - кривая, избегать

D:
damage - повреждение, повреждать
danger - опасность
daughter - дочь
day - день
death - смерть
debt - долг
decision - решение
degree - уровень, градус, степень
design - намереваться
desire - желание, желать 	destruction - разрушение
detail - детализировать, детали
development - развитие
digestion - вываривание
direction - управление
discovery - открытие
discussion - обсуждение
disease - болезнь
disgust - отвращение 	distance - дистанция
distribution - распределение
division - подразделение
doubt - сомнение
drink - пить, напиток
driving - вождение
dust - чистить, пыль

E:
earth - земля
edge - продвигаться, край
education - образование
effect - производить, эффект
end - заканчивать, конец 	error - ошибка
event - случай, событие
example - пример
exchange - обмен, обменивать
existence - существование 	expansion - расширение
experience - опыт, испытывать
expert - опытный, эксперт

F:
fact - факт
fall - падение, осень
family - семья
father - папа
fear - бояться, страх
feeling - чувство
fiction - беллетристика, фикция 	field - область, поле, выставлять
fight - борьба, бороться
fire -огонь
flame - пылать, пламя
flight - полет, рейс
flower - цветок
fold - сгиб, сворачивать 	food - еда, продовольствие
force - сила, вынуждать, вызывать
form - форма
friend - друг
front - выходить, фронт, передний
fruit - фрукт

G:
glass - стекло, стакан
gold - золото
government - государство 	grain - зерно
grass - трава
grip - власть, захват, захватывать 	group - группа
growth - рост
guide - гид, справочник, путеводитель

H:
harbor - приютить, питать, вставать на якорь, гавань
harmony - гармония
hate - ненавидеть, очень не хотеть, ненависть
hearing - слушание, слух 	heat - нагревать, высокая температура
help - помощь, помогать
history - история
hole - продырявливать, отверстие 	hope - надежда, надеяться
hour - час
humor - юмор

I:
ice - лёд
idea - идея
impulse - импульс
increase - увеличивать, увеличение 	industry - индустрия
ink - чернила
insect - насекомое
instrument - инструмент 	insurance - страховка
interest - интерес, процент, доля
invention - изобретение
iron - утюг, гладить

J:
jelly - превращать в желе, желе
join - присоединяться, объединение, соединение 	journey - путешествовать, поездка
judge - судья, судить 	jump - прыгать, прыжок

K:
kick - удар, ударить 	kiss - поцелуй, целовать 	knowledge - знание

L:
land - земля
language - язык
laugh - смеяться, смех
law - законный, закон
lead - принуждать, побеждать, вести, лидерство
learning - изучение, обучение 	leather - кожа
letter - письмо
level - уровень, выравнивать, направлять
lift - поднимать, лифт
light - освещать, легкий, свет
limit - ограничивать 	linen - льняной, полотно
liquid - жидкий, жидкость
list - список, перечислять
loss - потеря
love - любовь

M:
machine - машина
man - человек
mark - марка
market - рынок
mass - масса
meal - еда
measure - мера, измерять
meat - мясо
meeting - встреча 	memory - память
metal - металл
middle - средний, середина
milk - молоко
mind - ум, возражать
mine - мой, месторождение, мина
minute - минута
mist - туман
money - деньги 	month - месяц
morning - утро
mother - мать
motion - двигаться, движение, жест
mountain - гора, горный
move - двигать, шаг, движение
music - музыка

N:
name - имя
nation - нация
need - потребность, требоваться 	news - новости
night - ночь
noise - шум 	note - примечание, отмечать
number - число, номер

O:
observation - наблюдение
offer - предложение, предлагать
oil - масло 	operation - операция, действие
opinion - мнение
order - заказ, заказывать, приказывать 	organization - организация
ornament - украшение, украшать
owner - владелец

P:
page - страница
pain - боль, причинять боль
paint - краска, рисовать, красить
paper - бумага
part - часть, отделять, разделяться
paste - приклеивать, паста
payment - оплата
peace - мир
person - персона
place - размещать, помещать, занимать место, место
plant - завод, растение, прививать, сеять 	play - играть
pleasure - удовольствие
point - пункт, точка, указывать
poison - яд, отравлять
polish - полировать
porter - швейцар,носильщик
position - помещать, позиция
powder - порошок
power - сила, власть
price - цена
print - печатать  	process - обрабатывать, процесс
produce - продукт, производить
profit - прибыль, получать прибыль
property - свойства
prose - проза
protest - возражать, протест
pull - напряжение, тянуть
punishment - наказание
purpose - намереваться, цель
push - толчок, подталкивать

Q:
quality - качество, качественный 	question - вопрос 	 

R:
rain - дождь
range - диапазон, располагаться
rate - норма,разряд
ray - луч
reaction - реакция
reading - чтение
reason - рассуждать, причина, разум
record - рекордный, отчёт, делать запись
regret - сожаление, сожалеть 	relation - отношение
religion - религия
representative - представитель
request - запрос, просить
respect - уважение, уважать
rest - отдых, отдыхать, оставаться
reward - награда, вознаграждать
rhythm - ритм
rice - рис 	river - река
road - дорога
roll - рулон, ведомость, катиться, въезжать
room - комната
rub - протирать, тереться
rule - правило
run - бег, бегать

S:
salt - соль, солить
sand - песок
scale - измерять, масштаб
science - наука
sea - море
seat - сиденье, усаживать, место
secretary - секретарь
selection - выбор
self - сам
sense - чувство, значения, смысл, ощущать
servant - слуга
sex - секс, пол
shade - оттенок,тень, заштриховывать
shake - встряска, встряхивать, дрожать, потрясать
shame - позор, позорить
shock - шок, потрясать
side - сторона, примыкать
sign - знак, признак, подписывать
silk - шёлк
silver - серебро 	sister - сестра
size - размер
sky - небо
sleep - спать
slip - промах, бланк, подсовывать, скользить
slope - наклон, клониться
smash - удар, разбиваться
smell - запах, пахнуть
smile - улыбка, улыбаться
smoke - дым, курить
sneeze - чиханье, чихать
snow - снег
soap - мыло, мылить
society - общество
son - сын
song - песня
sort - вид, сортировать
sound - звук
soup - суп
space - пространство, космос 	stage - стадия, сцена, организовывать
start - начинать
statement - утверждение
steam - пар, париться, двигаться
steel - сталь
step - шаг, шагать
stitch - стежок, сшивать
stone - камень
stop - останавливаться, остановка
story - история
stretch - отрезки, протягивать, простираться
structure - структура
substance - вещество, сущность
sugar - сахар
suggestion - предложение, предположение
summer - лето
support - поддержка, поддерживать
surprise - сюрприз
swim - плаванье, плавать
system - система

T:
talk - разговор, говорить
taste - вкус, испытывать
tax - налог, облагать налогом
teaching - обучение
tendency - тенденция
test - проверять, тест
theory - теория 	thing - вещь
thought - мысль
thunder - гром, греметь
time - время
tin - олово,консервная банка
top - возглавлять, вершина, главный
touch - прикосновение, касаться 	trade - торговля, обменивать
transport  - транспорт, транспортировать
trick - уловка, обманывать
trouble - проблема, беспокоить
turn - поворот, поворачивать
twist - завихрение, крутить

U:
unit - единица 	use - использование, использовать 	 

V:
value - ценность, оценивать
verse - стих 	vessel - судно, сосуд
view - вид, взгляд, рассматривать 	voice - голос, высказывать

W:
war - война
wash - мытьё, стирать, чистить
waste - ненужный, отходы, трата
water - вода
wave - волна
wax - воск, натирать воском
weather - погода 	week - неделя
weight - вес, нагружать
wind - ветер
wine - вино
winter - зима, зимовать
woman - женщина
wood - лес 	wool - шерсть
word - слово
work - работа, работать
wound - проветривать, рана, ранить
writing - письмо

Y:
year - год

";
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringBasicWordPictureHTML = @"
A:
angle - угол, поворачивать;
ant - муравей;
apple - яблоко; 	arch - арка, дуга, выгибать;
arm - рука, вооружать;
army - армия 	 

B:
bag - сумка
ball - мяч
bank - банк
basin - бассейн
basket - корзина
bath - ванна, купаться
bed - кровать
bee - пчела
bell - колокольчик
berry - ягода 	bird - птица
blade - лезвие
board - доска
boat - лодка, судно
bone - кость
book - книга
boot - ботинок, загружать
bottle - бутылка
box - коробка
boy - мальчик 	brain - мозг
brake - тормоз, тормозить
branch - ветвь, отделение
brick - кирпич
bridge - мост
brush - щётка, кисть
bucket - ведро, черпать
bulb - луковица, выпирать
button - кнопка, застёгивать
baby - ребёнок, младенец

Скрыть 200 слов-картинок

C:
cake - пирог
camera - камера
card - карта, чесать
cart - везти
carriage - вагон
cat - кот
chain - цепь, сеть
cheese - сыр 	chest - грудь, сундук
chin - подбородок
church - церковь
circle - круг
clock - часы
cloud - облако
coat - пальто, покрывать
collar - воротник, хватать 	comb - расчёсывать
cord - шнур, связывать
cow - корова
cup - чашка
curtain - занавес, штора, занавешивать
cushion - подушка, смягчать

D:
dog - собака
door - дверь 	drain - утечка, истощать
drawer - ящик 	dress - платье, одевать
drop - капля, опускать

E:
ear - ухо
egg - яйцо 	engine - двигатель
eye - глаз 	 

F:
face - лицо
farm - ферма
feather - перо, украшать
finger - палец 	fish - рыба
flag - флаг, сигнализировать
floor - пол, этаж, дно
fly - муха, лететь 	foot - нога
fork - вилка
fowl - домашняя птица
frame - структура, рамка, создавать

G:
garden - сад
girl - девочка
glove - перчатка 	goat - коза
gun - оружие 	 

H:
hair - волосы
hammer - молоток
hand - рука
hat - шляпа 	head - голова
heart - сердце
hook - крюк, вербовать
horn - рожок 	horse - лошадь
hospital - больница
house - дом

I:
island - остров 	  	 

J:
jewel - драгоценный камень 	  	 

K:
kettle - чайник
key - ключ 	knee - колено
knife - нож 	knot - узел

L:
leaf - лист, покрывать листвой
leg - нога 	library - библиотека
line - линия, очередь, выравнивать 	lip - губа
lock - замок

M:
map - карта
match - спичка, сделки, соответствовать 	monkey - обезьяна
moon - луна 	mouth - рот, жевать
muscle - мускул

N:
nail - ноготь
neck - шея, обниматься
needle - игла 	nerve - нерв
net - чистый, сеть 	nose - нос
nut - орех

O:
office - офис 	orange - апельсин, оранжевый 	oven - духовка, печь

P:
parcel - пакет, распределять
pen - ручка
pencil - карандаш
picture - картина
pig - свинья 	pin - булавка, прикреплять
pipe - труба
plane - самолёт
plate - пластина
plow - плуг, пахать 	pocket - карман, присваивать
pot - горшок
potato - картофель
prison - тюрьма
pump - насос, качать

R:
rail - рельс, перевозить поездом
rat - крыса
receipt - квитанция 	ring - кольцо, звонить
rod - прут 	roof - крыша
root - корень

S:
sail - парус
school - школа
scissors - ножницы
screw - винт
seed - семя
sheep - овцы
shelf - полка
ship - корабль
shirt - рубашка
shoe - ботинок 	skin - кожа, очищать
skirt - юбка
snake - змея
sock - носок
spade - лопата
sponge - губка
spoon - ложка
spring - весна
square - квадрат
stamp - печать, марка, отпечатывать 	star - звезда
station - станция
stem - стебель, происходить
stick - палка, прикреплять
stocking - снабжать
stomach - живот, смелость, переваривать
store - магазин, запас
street - улица
sun - солнце

T:
table - стол
tail - хвост, выслеживать
thread - нить, пронизывать
throat - горло
thumb - листать, большой палец 	ticket - билет
toe - палец ноги
tongue - язык
tooth - зуб
town - город 	train - поезд
tray - поднос
tree - дерево
trousers - брюки

U:
umbrella - зонт

W:
wall - стена
watch - часы
wheel - колесо, вертеть 	whip - кнут, хлестать
whistle - свист, свистеть
window - окно 	wing - крыло
wire - провод
worm - червь 
";
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
