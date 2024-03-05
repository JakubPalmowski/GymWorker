# Training-and-diet-app

# Opis aplikacji:
Aplikacja ma za zadanie zarówno utworzyć intuicyjne środowisko do pracy z własnym ciałem jak i stworzyć platformę dla trenerów i dietetyków gdzie będą mogli pozyskać potencjalnych klientów. 
System został zaprojektowany z myślą o trzech użytkownikach: osobach aktywnie ćwiczących, trenerach oraz dietetykach. Struktura projektu pozwala na dostosowanie funkcjonalności do potrzeb każdej z grup. 
Do stworzenia systemu wykorzystane zostały takie technologie jak C#, ASP.NET Core, Entity Framework Core czy Angular.

# Instrukcja instalacji:

Przed uruchomieniem aplikacji, należy podmienić wartości "xyz" w appsettings.json.

Aplikacja frontendowa
1. Przed instalacją należy upewnić się, że na komputerze zainstalowane są odpowiednie narzędzia. Node.js w wersji 18.10.0 lub nowszej. Można to sprawdzić wpisując w konsole  node -v.
2. Jeśli Node.js nie jest zainstalowany lub zainstalowana jest starsza wersja, należy pobrać najnowszą wersję ze strony: https://nodejs.org/en.
3. Potrzebny jest także Angular w wersji 16.2 lub nowszej. Zainstalowaną wersję można sprawdzić używając komendy ng version. Jeśli wersja jest starsza lub Angular nie jest zainstalowany należy użyć komendy npm install -g @angular/cli.
4. W systemach windows wykonywanie skryptów PowerShell jest domyślnie wyłączone, są one wymagane do używania npm, aby je włączyć należy użyć komendy Set-ExecutionPolicy RemoteSigned
5. Kolejnym krokiem będzie uruchomienie komendy npm install z poziomu katalogu Training-and-diet-frontend
6. Po pobraniu wszystkich niezbędnych zależności wystarczy uruchomić komendę ng serve




Aplikacja backendowa
1. Przed instalacją należy upewnić się, że na komputerze zainstalowane są odpowiednia narzędzia. .NET sdk w wersji 8.0 lub nowszej. Można to sprawdzić wpisując w konsoli dotnet --list-sdks.
2. Jeśli sdk nie jest zainstalowany lub zainstalowana jest starsza wersja, należy pobrać najnowszą wersję ze strony: https://dotnet.microsoft.com/en-us/download/visual-studio-sdks
3. Potrzebny jest także Docker. Zainstalowaną wersję można sprawdzić używając komendy docker --version. Jeśli Docker nie jest zainstalowany, należy pobrać najnowszą wersję ze strony: https://www.docker.com/products/docker-desktop/
4. Kolejnym krokiem będzie uruchomienie komendy docker-compose up w głównym katalogu projektu - Training-and-diet-backend. Utworzy się obraz.
5. Następnie należy zainstalować Entity Framework Core CLI. Aby to zrobić uruchom komendę dotnet tool install --global dotnet-ef.
6. Potem uruchamiamy komendę dotnet restore .\Training-and-diet-backend.sln -f, aby pobrać wszystkie pakiety i biblioteki.
7. W celu stworzenia bazy danych uruchom komendę dotnet ef database update.
8. Ostatnim krokiem będzie uruchomienie aplikacji. W tym celu należy przejść do warstwy prezentacji - Training-and-diet-backend/TrainingAndDietApp.Presentation i uruchomić komendę dotnet run.



# Przykładowe widoki aplikacji: 
![ce7d43e9-f6e3-4e45-9f14-6a3690689200](https://github.com/JakubPalmowski/GymWorker/assets/101184580/cc9b9de3-d0cf-4d3f-ab5b-c6b29bb2b5d8)
![f51e0465-a160-4bc1-baf5-c20c428937de](https://github.com/JakubPalmowski/GymWorker/assets/101184580/37733e0d-5e1d-4824-b0fa-5a40835425aa)
![45ff3016-4a25-45e0-beda-8ac10246b291](https://github.com/JakubPalmowski/GymWorker/assets/101184580/3432d425-c044-43a5-85af-29fe18567a9a)
