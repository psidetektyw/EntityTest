# EntityTest

dla GET:
http://localhost:49982/api/doge  wyświetla wszystkie psy np u mnie wyszło: [{"dogId":1,"name":"Kola","numberOfWows":0},{"dogId":2,"name":"Figa","numberOfWows":0}]

http://localhost:49982/api/doge/(long)id wyświatla psa o podanym id 

dla POST:
http://localhost:44370/api/doge + np body(jest taka zakładka w postman): {
	"DogeId": 1,
	"Name": "Figa"

}
Dodaje pieska 

dla DELETE:
http://localhost:49982/api/doge/(long)id usunie pieska o podanym id 
