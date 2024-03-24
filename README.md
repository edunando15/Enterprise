# Enterprise Progetto N01
# Paradigmi Avanzati di Programmazione - modulo di Programmazione Enterprise.
1. Il backup del database si trova nella cartella "Database" nel progetto "Models". E' sufficiente importarlo da SQL Server Management Studio, facendo: tasto destro su "Database" -> "Restore Database" -> dalla sezione "General" -> selezionare "Devices" -> selezionare i tre puntini -> selezionare add -> selezionare il file .bak, che deve essere presente nella cartella indicata da SQL Server Management Studio.
2. Per avviare la soluzione, e' sufficiente aprirla con Visual Studio e selezionare come progetto di avvio "Web". Si aprira' automaticamente l'interfaccia di Swagger.
3. Fare attenzione ai filtri presenti di default nelle api: se non vengono svuotati (le stringhe messe a "" e gli oggetti a null), i risultati saranno alterati.
