import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Label, Input, FormGroup } from 'reactstrap';
import axios from 'axios';
import { NotesTable } from './NotesTable';
import { deleteNote, getNotes } from '../api';

export class DeleteModal extends Component {
    constructor(props) {
        super(props);
    };

    state = {

        items: [],
        deleteNoteData: {
            id: '',
            title: '',
            note: '',
            created: '',
            lastUpdated: ''

        },

        deleteNoteModal: false
    }

    toggleDeleteNoteModal() {
        this.setState({
            deleteNoteModal: !this.state.deleteNoteModal
        });
    }
    delete(id, title, note, created, lastUpdated) {
        //alert(i + t + n + c + l);

        this.setState({
            deleteNoteData: { ...this.state.deleteNoteData, id, title, note, created, lastUpdated }
        });

        this.toggleDeleteNoteModal();
    }

    deleteNote() {

        let { id, title, note, created, lastUpdated } = this.state.deleteNoteData;
        //axios.delete('api/Notes/' + this.state.deleteNoteData.id, {
        //    id, title, note, created, lastUpdated
        //}).then((response) => {
        //    console.log(response.data);
        //});

        deleteNote(this.state.deleteNoteData)
            .then(() => {
                getNotes()
                    .then(data => {
                        this.props.handleStateChangeAfterDel(data.data);
                        //this.setState({ itemsInAdd: data.data }, () => { console.log('stateChangedINAddModal', this.state.itemsInAdd) });
                    })
                    .catch(err => { console.log('error in delete', err) });
            })
            .catch(err => { console.log('error in delete', err) });

        this.toggleDeleteNoteModal();

       
    }


    render() {
        return (
            <div>

                <Modal isOpen={this.state.deleteNoteModal} toggle={this.toggleDeleteNoteModal} className={this.props.className}>
                    <ModalHeader toggle={this.toggleDeleteNoteModal}>Confirm Delete!</ModalHeader>
                    <ModalBody>
                        {this.state.deleteNoteData.title}
                        Are you sure you want to delete this note?
          </ModalBody>
                    <ModalFooter>
                        <Button color="danger" onClick={this.deleteNote.bind(this)}>Yes,Delete</Button>{' '}
                        <Button color="secondary" onClick={this.toggleDeleteNoteModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>

                
            )
    }




}