import axios from 'axios';
import './AnimalTable.css';


function AnimalTable({ animals, setAnimals, onSelectAnimal, onSelectMore, onSelectLess }) {

  function handleDelete(id) {
    axios.delete('http://localhost:5135/api/Animal' + `/${id}`) 
    .then(response => {
      console.log(response)
    }) 
  }

  

    return (
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Species</th>
            <th>Age</th>
            <th>Owner Name</th>
            <th>Delete</th>
            <th>Update</th>
            <th>More</th>
          </tr>
        </thead>
        <tbody>
          {animals.map((animal) => {
            return (
              <tr key={animal.id}>
                <td>{animal.name}</td>
                <td>{animal.species}</td>
                <td>{animal.age}</td>
                <td>{animal.owner ? `${animal.owner.firstName} ${animal.owner.lastName}` : "No Owner"}</td>
                <td><button type="button" onClick ={() => handleDelete(animal.id)}>Delete</button></td>
                <td><button type="edit" onClick ={() => onSelectAnimal(animal.id)}>Update</button></td>
                <td><button type="more" onClick ={() => onSelectMore(animal.id)}>+</button> <button type="more" onClick ={() => onSelectLess(animal.id)}>-</button></td>
              </tr>
            );
        })}
        </tbody>
      </table>
    );
}

export default AnimalTable;
