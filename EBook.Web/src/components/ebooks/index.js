import React from 'react';
import { useSelector } from 'react-redux';

import EBook from '../ebook';
import { eBooksSelector } from '../../redux/reducers/ebooks';

const EBooks = () => {
  const eBooks = useSelector(eBooksSelector);

  return (
    <React.Fragment>
      {
        eBooks.map(eBook =>
          <EBook key={eBook.id} eBook={eBook} />)
      }
    </React.Fragment>
  )
};

export default EBooks;