import React, { useState } from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import './index.css';

const Search = ({ label, submitHandler }) => {
  const [query, setQuery] = useState('');

  const onQueryChangeHandler = e => {
    setQuery(e.target.value);
  }

  const onSubmit = () => {
    submitHandler(query);
  }

  return (
    <div className="search-form">
      <TextField id="standard-basic"
        label={`${label}`}
        onChange={onQueryChangeHandler} />

      <Button onClick={onSubmit}
        variant="outlined"
        color="primary"
        disableElevation>
        Search
      </Button>
    </div>
  );
};

export default Search;