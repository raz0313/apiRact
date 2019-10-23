import React from "react";
import axios from "axios";
import Card from "./Card";
import NewCard from "./NewCard";
import "bootstrap/dist/css/bootstrap.min.css";

import "./App.css";

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      items: []
      
      
    };
    this.getData();
  }

  getData(){
axios.get("http://localhost:59846/api/person").then(res=>{
console.log(res.data);
this.setState({items:res.data});
});
  }

  render() {
    return (
      <div className="App">
        <h1>test</h1>
        <NewCard/>
        {
          this.state.items.map(item=>(
            <Card
            id = {item.employeeId}
            firstName= {item.firstName}
            lastName = {item.lastName}
            
            />
          ))
        }
      
      </div>
    );
  }
}

export default App;