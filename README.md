# SFF_API

Inlämningsuppgift

I detta första uppdrag så ska ni jobba för Sveriges Förenade Filmstudios (SFF) och utveckla ett API som ﬁlmstudion kan anropa för att beställa ﬁlm.
SFF fungerar på så sätt att lokala ﬁlmintresserade bildar föreningar som ingår i SFF som är förbundet för hela Sverige. SFF har rätt från ﬁlmbolagen att låna ut ett visst antal exemplar av olika ﬁlmer till dom lokala föreningar som sedan visar dem på exempelvis kulturbiograferna i sina städer. Förut skedde detta via blanketter och dyr transport av fysiska ﬁlmrullar - men idag sker detta såklart digitalt. 
De ﬁlmer som inte hunnit digitaliseras ännu är dock reglerade för hur många ﬁlmer som får lånas ut samtidigt, så SFF önskar nu att du tar fram ett API för att hålla koll på vilka ﬁlmer som ﬁnns tillgängliga för föreningarna att låna digitalt! 


Din API-lösning ska vara byggt i ASP.NET Core 3.0 eller 3.1. 

● Alla endpoints ska ta emot eller returnera JSON-data 

● I API:et ska resursen ﬁlmer ﬁnnas: 

    ○ Det ska gå att lägga till en ny ﬁlm 
    ○ Det ska gå att ändra hur många studios som kan låna ﬁlmen samtidigt 
    ○ Det ska gå att markera att en ﬁlm är utlånad till en ﬁlmstudio (man får inte låna ut den mer än ﬁlmen ﬁnns tillgänglig (max-antal samtidiga utlåningar)
      ○ Det ska gå att ändra så att ﬁlmen inte längre är utlånad till en viss ﬁlmstudio
    
    
● En annan resurs som ska ﬁnnas är ﬁlmstudios: ○ Det ska gå att registrera en ny ﬁlmstudio 

    ○ Det ska gå att ta bort en ﬁlmstudio ○ Det ska gå att byta namn, och ort på en ﬁlmstudio 
    ○ Via API:et ska man kunna få fram vilka ﬁlmer som en viss studio har lånat 
    
    
● När ﬁlmstudiorna har visat ﬁlmerna rapporterar de in ett betyg och ibland även en triva på ﬁlm 

    ○ Det ska gå att skapa ett nytt trivia objekt som håller koll på en liten anekdot för en viss ﬁlm (Kan vara en string , kolla på IMDB för exempel) 
    ○ Det ska gå att ta bort inskriven trivia ○ Det ska också gå att rapportera in ett betyg mellan 1 och 5, det är viktigt att komma ihåg vilken studio som gav betyget för vilken ﬁlm. 
