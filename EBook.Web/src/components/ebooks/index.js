import React from 'react';
import { useSelector } from 'react-redux';

import EBook from '../ebook';
import { eBooksSelector } from '../../redux/reducers/ebooks';
import './index.css';

const EBooks = () => {
  const eBooks = useSelector(eBooksSelector);

  return (
    <div className="ebooks-list">
      {
        eBooks.map(eBook =>
          <EBook key={eBook.id} eBook={eBook} />)
      }
    </div>
  )
};

export default EBooks;