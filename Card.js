import React from "react";
import axios from "axios";

import "bootstrap/dist/css/bootstrap.min.css";

import "./App.css";
class Card extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        isEdit:true,
        id:'',
        firstName:'',
        lastName:''
        
    
    };
   
    
  }

  edit=e=>{
this.setState({
    isEdit:false,
    firstName:this.props.firstName,
    lastName:this.props.lastName,
    id:this.props.id

});
console.log(this.state);
  };

  hendelChangeFname= e=>{
 this.setState({firstName:e.target.value});

  };
  hendelChangeLname= e=>{
  this.setState({lastName:e.target.value});
};
cancel=e=>{
    this.setState({isEdit:true});
};
dalete=e=>{
    axios.delete(`http://localhost:59846/api/person/${this.props.id}`).then(res=>{
        window.location.reload();
        
    });
};

save=e=>{
axios.put(`http://localhost:59846/api/person/${this.props.id}`,this.state).then(res=>{
    console.log(res.data)
});

};

  render() {
    if(this.state.isEdit){
        return (
            <div>
              <h3>{this.props.id}</h3>
              <h3>{this.props.firstName}</h3>
              <h3>{this.props.lastName}</h3>
              <button onClick={this.edit}>edit</button>
              <button onClick={this.dalete}>dalete</button>
            </div>
          );
    }else{
        return (
            <div>
                <form onSubmit={this.save}>
              <h3>{this.props.id}</h3>
              <h3><input type="text" onChange={this.hendelChangeFname} value={this.state.firstName} /> </h3>
              <h3><input type="text" onChange={this.hendelChangeLname} value={this.state.lastName} /> </h3>
              <button type="submit">save</button>
              <button onClick={this.cancel}>cancel</button>
              </form>
            </div>
          );
    }
    
    
  }
}

export default Card;