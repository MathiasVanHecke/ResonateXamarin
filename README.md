# Resonate Xamarin
## Inleiding
Dit is de applicatie die geschreven is in Xamarin. Men kan dit uitvoeren op een Android toestel die minimaal een api level heeft van 28.

## Opstart process
Om het project te starten moeten we enkele dingen uitvoeren om het project goed te krijgen.

### Nodige installaties
Zorg ervoor dat volgende programma's geïnstalleerd zijn:
- Microsoft Visual Studio 2017
-- Met Xamarin
-- .Net 4.2
- Een Android emulator of fysiek toestel met api level 28

### Opstarten
Nadat men het project lokaal heeft opgeslagen, zou men instaat moeten zijn het zonder problemen op te starten.

### Flow van het project & duiding
Dit is de flow die de gebruiker moet volgen als ze de applicatie gebruiken.

|Nummer|Pagina|Duiding|
|--|--|--|
|1|Login Page| Scherm als men de eerste keer de applicatie opstart.|
|2|Register To Spotify Page| De gebruiker krijgt een webbrowser te zien om Resonate Toegang te geven tot hun Spotify Data|
|3|Register Page|De gebruiker kan de opgehaalde data aanpassen naar zijn huidige instellingen. Deze data wordt opgeslagen op de Resonate Database na op register knop de duwen.|
|4|Discover Page| De gebruiker ziet alle artiesten & genres die in de database aanwezig zijn.|
|5|Swipe Page| Alle gebruikers die een potentiële matches zijn, worden hier getoond. Men kan door middel van een swipe beweging aantonen of ze de getoonde gebruiker al dan niet leuk vinden.|
|6|Swipe Profile Page| Als men op de vorige pagina op de foto klikt kan men alle informatie van de potentiële match zien.|


> Als de gebruiker al eens is ingelogd worden de eerste drie schermen niet getoond. Men controleert dit of er al dan niet al een gebruikers id in local storage is opgeslagen.

## Mogelijke uitbreidingen
- Een pagina voor alle effectieve matches.
- Een duidelijkere navigatie tussen pagina's. (header navigatie)
- Berichten sturen naar effectieve matches, met werking van real time data.
- Een instelling pagina voorzien.
- Een pagina voor huidige instellingen te veranderen van de gebruiker.
