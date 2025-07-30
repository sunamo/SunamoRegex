using System.Text;
using System.Text.RegularExpressions;

namespace SunamoRegex.Tests;
public class RegexHelperTests
{
    [Fact]
    public void IsTelephoneTest()
    {
        RegexHelper.IsTelephone(@"
												
													
														
															
			
				
					
				
			
		
														
													
												
											");
    }

    [Fact]
    public void CzechAccountNumbersTest()
    {
        var input = @"341944165/0300 3265290/Rosalinda34
3200117143/0800 tvoje_madam_69
https://www.amateri.com/user/2428972/Panda87 = https://www.amateri.com/user/3111351/Pandora666
2648539016/3030 https://www.amateri.com/en/user/3264640/Napismipusinko
336436684/0300 čekám ju micka125 
4973929033/0800 PlnejsiPostavy
5410180043/0800 podvodnixe 
264095613/0600 
2302596785/2010 - Klara Kkb
5391356073/0800 https://www.amateri.com/en/user/3117002/Zanetka224
318109022/0300 lidinka 

2552199029/3030 FoteckovaVila 
5160524033/0800 https://www.amateri.com/en/user/3290014/Pipi_mimi romka
https://www.amateri.com/user/3018308/Lasenka00
3233736012/3030 https://www.amateri.com/user/3328869/Knedlicek713
3271666019/3030 https://www.amateri.com/user/3267627/Bozeenkaa 

798766004/5500 - 
362116/0300 131-1457770237/0100  - https://www.amateri.com/en/user/3190808/Mrsinka021
2878714123/0800 - https://www.amateri.com/en/user/3341783/MaruskaCv
1586853004/5500 https://www.facebook.com/profile.php?id=61559062845423 Josefina Špronglová 
7147258083/0800 - komunikuje přes mail novapetra99@gmail.com . Zde pošle číslo účtu ale fotky už nepřijdou. 
336436684/0300 https://www.amateri.com/en/user/3115244/sabinka124 
AlenkaVysocina - 1989081002/6363  
https://www.amateri.com/en/user/3081946/Milujuorgazmy - 2878050064/3030
3080148/Jentvaneznama - 2552199053/3030
5431442401/6363 https://www.amateri.com/en/user/3194822/powerpussy 
1685048019/6363  https://www.amateri.com/user/2909959/Mirecka84

3050137017/3030 Beaatrixx 



4646047033/0800 

105457488/0100 https://www.amateri.com/user/3350383/Mony_mony";

        MatchCollection matches = RegexHelper.rCzechAccountNumber.Matches(input);

        List<string> accountNumbers = new();

        foreach (Match match in matches)
        {
            accountNumbers.Add(match.Value);
        }

        StringBuilder sb = new StringBuilder();

        foreach (var item in accountNumbers)
        {
            //sb.AppendLine($"site:https://podvodnabazaru.cz \"{item}\"");
            sb.AppendLine($"https://www.google.com/search?q=site%3Ahttps%3A%2F%2Fpodvodnabazaru.cz+%22{item}%22");
        }

        var s = sb.ToString();
    }
}
