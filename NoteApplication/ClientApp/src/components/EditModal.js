import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Label, Input, FormGroup } from 'reactstrap';
import axios from 'axios';
import { NotesTable } from './NotesTable';
import { updateNote, getNotes } from '../api';


export class EditModal extends Component {
    constructor(props) {
        super(props);
    };

    state = {

        items:[],
        editNoteData: {
            id:'',
            title: '',
            note: '',
            created:'',
            lastUpdated:''

        },

         editNoteModal: false
    }


    toggleEditNoteModal() {
        this.setState({
            editNoteModal: !this.state.editNoteModal
        });
    }

    edit(i,t,n,c,l) {
        //alert(i + t + n + c + l);
        this.setState({
            editNoteData: {
                id:i,
                title: t,
                note: n,
                created:c,
                lastUpdated: new Date().getFullYear() + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate()

            }
        });
       
        this.toggleEditNoteModal();
    }

    updateNote() {

        let { id, title, note, created, lastUpdated } = this.state.editNoteData;
        //axios.put('api/Notes/' + this.state.editNoteData.id, {
        //    id, title, note, created, lastUpdated
        //}).then((response) => {
        //    console.log(response.data);
        //    });
        updateNote(this.state.editNoteData)
            .then(() => {
                getNotes()
                    .then(data => {
                        this.props.handleStateChangeAfterUpdate(data.data);
                        //this.setState({ itemsInAdd: data.data }, () => { console.log('stateChangedINAddModal', this.state.itemsInAdd) });
                    })
                    .catch(err => { console.log('error in update', err) });
            })
            .catch(err => { console.log('error in  update', err) });

        this.toggleEditNoteModal();


    }


    


        

        

    


    render(){
        return (

            <div>
                
                <Modal isOpen={this.state.editNoteModal} toggle={this.toggleEditNoteModal.bind(this)} className={this.props.className}>
                    <ModalHeader toggle={this.toggleEditNoteModal.bind(this)}>Edit Note</ModalHeader>
                    <ModalBody>
                        <FormGroup>
                            <Label for="title">Title</Label>
                            <Input id="title" value={this.state.editNoteData.title} onChange={(e) => {
                                let { editNoteData } = this.state;
                                editNoteData.title = e.target.value;
                                this.setState({ editNoteData });
                            }} />
                        </FormGroup>

                        <FormGroup>
                            <Label for="note">New Note</Label>
                            <Input id="note" value={this.state.editNoteData.note} onChange={(e) => {
                                let { editNoteData } = this.state;
                                editNoteData.note = e.target.value;
                                this.setState({ editNoteData });
                            }} />
                        </FormGroup>
                    </ModalBody>
                    <ModalFooter>
                        
                        <Button color="success" onClick={this.updateNote.bind(this)}>Update</Button>{' '}
                        <Button color="secondary" onClick={this.toggleEditNoteModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>
            
            )
}
}