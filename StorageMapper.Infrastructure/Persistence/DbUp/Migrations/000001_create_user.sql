CREATE TABLE IF NOT EXISTS users (
    id uuid PRIMARY KEY,
    first_name varchar(10) NOT NULL,
    surname varchar(50) NOT NULL,
    phone_number text,
    email varchar(60) NOT NULL UNIQUE,
    password_hash text NOT NULL
);
