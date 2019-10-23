import React from "react";
import axios from "axios";

import "bootstrap/dist/css/bootstrap.min.css";

import "./App.css";
class App extends React.Component {
  constructor(props) {
    super(props);
    this.state={
        firstName:'',
         lastName:''
            };
    
      }
  changeFname=e=>{
this.setState({firstName: e.target.value});
  };
  changeLname=e=>{
    this.setState({lastName: e.target.value});
  };
    Add=e=>{
    axios.post(`http://localhost:59846/api/person`,this.state).then(res=>{
console.log(res.data);
    });
};

  render() {
    return (
      <div >
          <form onSubmit={this.Add}>
        <h1>new Person</h1>
       <input type="text" onChange={this.changeFname} />
       <input type="text" onChange={this.changeLname} />
       <button type="submit">Add</button>
       </form>
      </div>
    );
  }
}

export default App;