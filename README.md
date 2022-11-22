# la-mia-pizzeria-crud-mvc

22/11/22
Completiamo le pagine di gestione delle nostre pizze!

Abbiamo la pagina con la lista di tutte le pizze, quella con i dettagli della singola pizza, quella per crearla...cosa manca?

Dobbiamo realizzare :
	- pagina di modifica di una pizza
	- cancellazione di una pizza cliccando un pulsante presente nella grafica di ogni singolo prodotto mostrato nella lista in homepage


# la-mia-pizzeria-post

22/11/22
Abbiamo la lista delle pizze, abbiamo i dettagli delle pizze...perchè non creare la pagina per la creazione di una nuova pizza?

Aggiungiamo quindi tutto il codice necessario per mostrare il form per la creazione di una nuova pizza e per il salvataggio dei dati nella lista che abbiamo in memoria.

Nella index creiamo ovviamente il bottone “Crea nuova pizza” che ci porta a questa nuova pagina creata.

Ricordiamoci che l’utente potrebbe sbagliare inserendo dei dati : gestiamo quindi la validazione!

Ad esempio verifichiamo che :
	- i dati della pizza siano tutti presenti
	- il campi di testo non superino una certa lunghezza
	- il prezzo abbia un valore valido (ha senso una pizza con prezzo minore o uguale a zero?)

Bonus 
Prevediamo una validazione in più : 
	- vogliamo che la descrizione della pizza contenga almeno 5 parole.


# la-mia-pizzeria-model

21/11/2022
Ciao ragazzi, andiamo avanti con l’applicazione per gestire la nostra pizzeria. Lo scopo di oggi è quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.
Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d’ora in avanti.
L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.
Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.
Ogni pizza dell’elenco avrà un pulsante che se cliccato ci porterà a una pagina che mostrerà i dettagli di quella singola pizza.
Dobbiamo quindi inviare l’id come parametro dell’URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.
La view a quel punto li mostrerà all’utente con la grafica che preferiamo.
Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il “mapping di default” dei controller...altrimenti quale pagina viene caricata se richiamo l’url “/” della nostra webapp?