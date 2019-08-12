# TestTaskForSKB

Японцы бесконечно влюблены в технику, которая их окружает. Они внимательно следят за всеми техническими новинками и стараются пользоваться самыми современными и «умными» из них. У Дена и Сергея есть гениальный план: они хотят создать текстовый редактор, который покорит японцев. Важнейшей уберинтеллектуальной функцией редактора должна стать функция автодополнения. Если пользователь набрал несколько первых букв слова, редактор должен предложить ему самые правдоподобные окончания.
Ден и Сергей уже собрали огромное количество японских текстов. Для каждого слова японского языка они посчитали число раз, которое оно встречается в текстах. Если пользователь уже ввел несколько букв, то редактор должен показать не более десяти самых часто употребляемых слов, начинающихся со введенных пользователем букв, отсортированных по убыванию частоты упоминания.
Помогите Сергею с Деном перевернуть рынок текстовых редакторов.
Исходные данные
В первой строке находится единственное число N (1 ≤ N ≤ 105) — количество слов в найденных текстах. Каждая из следующих N строк содержит слово wi (непустая последовательность строчных латинских букв длиной не более 15) и целое число ni (1 ≤ ni ≤ 106) — число раз, которое встречается это слово в текстах. Слово и число разделены единственным пробелом. Ни одно слово не повторяется более одного раза. В (N + 2)-й строке находится число M (1 ≤ M ≤ 15000). В следующих M строках содержатся слова ui (непустая последовательность строчных латинских букв длиной не более 15) — начала слов, введенных пользователем.
Результат
Для каждой из M строк необходимо вывести наиболее часто употребляемые японские слова, начинающихся с ui, в порядке убывания частоты. В случае совпадения частот слова необходимо сортировать по алфавиту. Если существует больше десяти возможных вариантов, то вывести нужно лишь первые десять из них. Варианты дополнения для каждого слова необходимо разделять переводами строк.
Пример
исходные данные	
5
kare 10
kanojo 20
karetachi 1
korosu 7
sakura 3

результат
3
k
ka
kar
kanojo
kare
korosu
karetachi

kanojo
kare
karetachi

kare
karetachi
Автор задачи: Ден Расковалов
Источник задачи: XI командный чемпионат Урала по спортивному программированию, Екатеринбург, 21 апреля 2007 г

http://acm.timus.ru/problem.aspx?space=1&num=1542&locale=ru
