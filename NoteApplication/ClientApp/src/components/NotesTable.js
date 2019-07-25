import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { Table } from 'reactstrap';
import { AddModal } from './AddModal';
import { EditModal } from './EditModal';
import { DeleteModal } from './DeleteModal';
import { getNotes } from '../api';

export class NotesTable extends Component {
    constructor() {
        super();
        this.handleStateChange = this.handleStateChange.bind(this);
        this.handleStateChangeAfterDel = this.handleStateChangeAfterDel.bind(this);
        this.handleStateChangeAfterUpdate = this.handleStateChangeAfterUpdate.bind(this);
    }
    

   state = {
        items: [],
        editingData: {
            id: '',
            title: '',
            lastUpdated: ''

        }
    }



    componentWillMount() {
        getNotes()
            .then(data => {
                this.setState({ items: data.data }, () => { console.log('stateChanged', this.state) });
            })
            .catch(err => { console.log('error in notes table get', err) });

    }



    editNote = (selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated) => {

        this.refs.editmodal.edit(selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated);
      
    }

    deleteNote = (selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated) => {
        console.log("1", this.refs);
        this.refs.deletemodal.delete(selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated);
        console.log("2 ", this.refs);
    }

    


    handleStateChange(itemsAfterAdd) {
        //event.preventDefault();
       //let i =this.state.items
        //i.push(value);
        console.log('update state to:', itemsAfterAdd);
        this.setState({ items: itemsAfterAdd }, () => { console.log('handle state change', this.state)});
    }

    handleStateChangeAfterUpdate(itemsAfterUpdate) {
        console.log('update state to:', itemsAfterUpdate);
        this.setState({ items: itemsAfterUpdate }, () => { console.log('handle state change after update', this.state) });
    }

    handleStateChangeAfterDel(itemsAfterDel) {

        console.log('update state to:', itemsAfterDel);
        // this.setState({ items: itemsAfterDel }, () => { console.log('handle state change after del', this.state) });
        this.setState({ items: itemsAfterDel }, () => { console.log('handle state change after del', this.state) });



        //let items = this.state.items;

       
        //items.splice(items.indexOf(valueId))
        //this.setState({ items: items })
    }
    


    render() {
    
        return (
            <div>
                <h1>Note Book</h1>
                <AddModal handleStateChange={this.handleStateChange} />
              
                
                <Table dark>
                    <thead>
                        <tr>
                           
                            <th>Title</th>
                            <th>Description</th>
                            <th>Created</th>
                            <th>Last Upadted</th>
                        </tr>
                    </thead>
                    {
                        this.state.items.map(item => (
                            
                            <tr key={item.id}>
                               
                                <td> {item.title}</td>
                                <td> {item.note}</td>
                                <td> {item.created}</td>
                                <td> {item.lastUpdated}</td>
                                <td>

                                    <EditModal note={item} onEdit={this.props.onEdit} ref="editmodal" handleStateChangeAfterUpdate={this.handleStateChangeAfterUpdate} />

                                    <Button color="primary" size="sm" className="mr-2" onClick={this.editNote.bind(this, item.id, item.title, item.note, item.created, item.lastUpdated)}>Edit</Button>
                                    <DeleteModal /*onDelete={() => this.props.onDelete(item.id)}*/ ref="deletemodal" handleStateChangeAfterDel={this.handleStateChangeAfterDel} />
                                    <Button color="danger" size="sm" onClick={this.deleteNote.bind(this, item.id, item.title, item.note, item.created, item.lastUpdated)}>Delete</Button>
                                </td>


                            </tr>
                           
                                                   


                        )
                        )
                    }
                </Table>

            </div>


        );
    }
}