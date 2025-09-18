CREATE TABLE IF NOT EXISTS refresh_tokens (
    id uuid PRIMARY KEY,
    token varchar(200) NOT NULL UNIQUE,
    user_id uuid NOT NULL REFERENCES users,
    expires_on_utc timestamp with time zone NOT NULL
 );
