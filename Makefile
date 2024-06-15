.PHONY: start

UNAME_S := $(shell uname -s)
DC := $(shell docker-compose --version)

start:
ifndef DC
	$(error "docker-compose is not installed")
endif
ifeq ($(UNAME_S),Linux)
	@sudo docker-compose -f docker-compose.yml up -d
endif
ifeq ($(UNAME_S),Darwin)
	@docker-compose --file docker-compose.yml up -d
endif

stop:
ifndef DC
	$(error "docker-compose is not installed")
endif
ifeq ($(UNAME_S),Linux)
	@sudo docker-compose --file docker-compose.yml stop
endif
ifeq ($(UNAME_S),Darwin)
	@docker-compose --file docker-compose.yml stop
endif
