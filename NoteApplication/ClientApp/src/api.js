import axios from 'axios';

export const getNotes = async () => {
    try {
        const response = await axios.get('api/notes');
        console.log('GET api/notes', response.data);
        return response;

    } catch (error) {
        console.error('GET api/notes', error);
        return null;
    };
};

export const saveNotes = async (data) => {
    try {
       const res= await axios({
            method: 'post',
            url: 'api/Notes',
            data: {
                //title: this.state.newNoteData.title,
                //note: this.state.newNoteData.note,
                //created: this.state.newNoteData.created,
                //lastUpdated: this.state.newNoteData.lastUpdated
                title: data.title,
                note: data.note,
                created: data.created,
                lastUpdated: data.lastUpdated
                
            }
        })
        console.log('POST api/notes', res);
        return res;
           //.then((response) => console.log('POST api/notes', response.data));
        
    } catch (error) {
        console.error('POST api/notes', error);
        return null;
    };


   
}

export const deleteNote = async (data) => {
    let { id, title, note, created, lastUpdated } = data;
    try {

        const res = await axios.delete('api/Notes/' + data.id, {
            id, title, note, created, lastUpdated
        })

        console.log('DELETE api/notes', res);
        return res;


    } catch (error) {
        console.error('DELETE api/notes', error);
        return null;
    };
}


export const updateNote = async (data) => {

    let { id, title, note, created, lastUpdated } = data;

    try {
        const res = await axios.put('api/Notes/' +data.id, {
            id, title, note, created, lastUpdated
        })
        console.log('PUT api/notes', res);
        return res;
     

    } catch (error) {
        console.error('PUT api/notes', error);
        return null;

    }


    


}