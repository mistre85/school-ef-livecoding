// See https://aka.ms/new-console-template for more information



using Microsoft.EntityFrameworkCore;
using school_ef_livecoding;

//il contesto ci serve per accedere allo strato ORM e "trasforamre" le nostre semplici classi in MODEL
//questo accadrà se ci sarà un database migrato con dotnet ef
SchoolContext db = new SchoolContext();

//possiamo da quel momento creare istanze e darne dei valori senza influenzare direttamente il db...
Student francesco = new Student();
francesco.Name = "Francesco";
francesco.Surname = "Polidoro";
francesco.Email = "frapo@aubra.it";

Student paolo = new Student();
paolo.Name = "Paolo";
paolo.Surname = "Mistretta";
paolo.Email = "paolo@mistre.it";

db.Students.Add(francesco);
db.Students.Add(paolo);

//... per passare lo stato dei dati dalle istanze al db dobbiamo salvare
db.SaveChanges();

//da questo memento i dati sono sincronizzati nelle istanze (dal db) e quindi possiamo

//faccio notare che la conversione diretta delle funzioni LINQ (method syntax) non produce l'istanza del model ma 
//una interfaccia intermedia che mi mette a disposizoine altri metodi...
IQueryable<Student> resultOfQuery = db.Students.Where(student => student.Email == "paolo@mistre.it");

//...tra cui First(), con cui posso recuperare il PRIMO record, e quindi la prima istanza 
Student studente = resultOfQuery.First();

//posso fare la stessa cosa anche con linq query syntax
studente = db.Students.Where(student => student.Email == "paolo@mistre.it").First();
studente = (from s in db.Students
         where s.Email == "paolo@mistre.it"
         select s).First();


//Per creare una nuova review ho due possibilità

//creare una nuova review...
Review review = new Review();


review.Title = "Review " + new Random().Next(1000);
review.Text = "questa è un'altra review di Paolo";

//.. e associare l'istanza dello studente di modo che si creai una relazione del db
review.Student = paolo;
db.Reviews.Add(review);
db.SaveChanges();

//OPPURE

//posso assocciare la review alla lista di review dell'utente direttamente dalla sua properties,
//che però deve essere "istanziata" nella query
studente = (from s in db.Students
            where s.Email == "paolo@mistre.it"
            select s).Include("Reviews").First();


//altrimenti, la prossima istruzione genererebbe un NULL e quindi un'eccezione per un tentativo di accesso

paolo.Reviews.Add(review);
db.SaveChanges();

