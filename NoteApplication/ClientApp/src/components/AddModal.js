import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Label, Input, FormGroup } from 'reactstrap';

export class AddModal extends Component {

    state = {
        newNoteModal: false,
        newNoteData: {
            title: '',
            noteDescription: ''
        }
    }


    toggleNewNoteModal() {
        this.setState({
            newNoteModal: !this.state.newNoteModal
        });
    }




    render() {
        return (

            <div>
                <Button color="success" onClick={this.toggleNewNoteModal.bind(this)}>Add Note</Button>
                <Modal isOpen={this.state.newNoteModal} toggle={this.toggleNewNoteModal.bind(this)} className={this.props.className}>
                    <ModalHeader toggle={this.toggleNewNoteModal.bind(this)}>New Note</ModalHeader>
                    <ModalBody>
                        <FormGroup>
                            <Label for="title">Title</Label>
                            <Input id="title" value={this.state.newNoteData.title} onChange={(e) => {
                                let { newNoteData } = this.state;
                                newNoteData.title = e.target.value;
                                this.setState({ newNoteData });
                            }} />
                        </FormGroup>

                        <FormGroup>
                            <Label for="noteDescription">New Note</Label>
                            <Input id="noteDescription" value={this.state.newNoteData.noteDescription} onChange={(e) => {
                                let { newNoteData } = this.state;
                                newNoteData.noteDescription = e.target.value;
                                this.setState({ newNoteData });
                            }} />
                        </FormGroup>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="success" onClick={this.toggle}>Save</Button>{' '}
                        <Button color="secondary" onClick={this.toggleNewNoteModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
} 
